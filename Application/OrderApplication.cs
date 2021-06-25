using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public List<Order> listItem()
        {
            List<Order> list = new List<Order>();

            try
            {
                list = _dataContext.Orders.Include(o => o.Items).ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return list;
        }
        public  bool addItem(Guid id)
        {
            var order = new Order();
            Item menuItem = _dataContext.Items.FirstOrDefault(a => a.ItemId == id);
            if (menuItem == null) return false;

            order.Items.Add(menuItem);
          //  menuItem.Orders.Add(order);
            _dataContext.Orders.Add(order);

            //order.ItemOrder.Add(itorder);

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
