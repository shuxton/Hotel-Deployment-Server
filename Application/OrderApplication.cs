using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Application
{
    public class OrderApplication
    {
        private readonly DataContext _dataContext;
        public OrderApplication(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Order> listOrders()
        {
            List<Order> list = new List<Order>();

            try
            {
              list = _dataContext.Orders.Include(o => o.ItemOrders).ThenInclude(i=>i.Item).ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return list;
        }

        public Order getOrder(Guid id)
        {
            Order order = new Order();
            try
            {
                order = _dataContext.Orders.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return order;

        }
        //Todo Add calculations

        public bool createOrder(Guid [] ids, Order order)
        {
            order.Time = DateTime.UtcNow;
            order.OrderNo = _dataContext.Orders.Count(t => true)+1;
            order.Total = 0;
            Dictionary<Guid, int> quantity = new Dictionary<Guid, int>();
            
            foreach(var id in ids)
            {
 
                if (quantity.ContainsKey(id))
                {
                    quantity[id] += 1;
                }
                else
                {
                    quantity.Add(id, 1);
                }

            }

            foreach(var id in quantity)
            {
                Item menuItem = _dataContext.Items.FirstOrDefault(a => a.Id == id.Key);
                if (menuItem == null) return false;
                order.Total += (menuItem.Price*id.Value);
                _dataContext.ItemOrder.Add(new ItemOrder { Order = order,Item=menuItem, Quantity = id.Value });
            }

            order.CGST = _dataContext.AdminMaster.FirstOrDefault(t => true).RateCGST * order.Total / 100;

            order.SGST = _dataContext.AdminMaster.FirstOrDefault(t => true).RateSGST * order.Total / 100;


            
            order.GrandTotal = order.Others + order.Total + order.SGST + order.CGST - (order.Discount * order.Total / 100);

            _dataContext.Orders.Add(order);


            var num = 0;
            try
            {
                num = _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            if (num > 0)
                return true;
            return false;
        }
    }
}
