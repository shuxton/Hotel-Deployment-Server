using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class MenuApplication
    {
        private readonly DataContext _dataContext;
        public MenuApplication(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public List<Item> listItem()
        {
            List<Item> list = new List<Item>();
            
            try
            {
                list = _dataContext.Items.Include(o => o.Orders).ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return list;
        }

        public Item getItem(Guid id)
        {
            Item item = new Item();
            try
            {
                item = _dataContext.Items.FirstOrDefault(a => a.ItemId == id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return item;

        }

        public bool addItem(Item item) {
            _dataContext.Items.Add(item);
            var num = 0;
            try
            {
               num = _dataContext.SaveChanges();
            }catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            if(num>0)
            return true;
            return false;
        }

        public bool updateItem(Guid id,Item item)
        {
            var num = 0;
            var old = _dataContext.Items.FirstOrDefault(a => a.ItemId == id);
            if (old == null) return false;
            try
            {
                old.IsVeg = item.IsVeg;
                old.Name = item.Name;
                old.Price = item.Price;
                old.Description = item.Description;
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

        public bool deleteItem(Guid id)
        {
            var num = 0;
            var item = _dataContext.Items.FirstOrDefault(a => a.ItemId == id);
            if (item == null) return false;
            try
            {
                _dataContext.Items.Remove(item);
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
