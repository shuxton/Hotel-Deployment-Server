using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class Menu
    {
        private readonly DataContext _dataContext;
        public Menu(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public List<MenuItem> listItem()
        {
            List<MenuItem> list = new List<MenuItem>();
            
            try
            {
                list = _dataContext.MenuItems.ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return list;
        }

        public MenuItem getItem(Guid id)
        {
            MenuItem item = new MenuItem();
            try
            {
                item = _dataContext.MenuItems.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return item;

        }

        public bool addItem(MenuItem item) {
            _dataContext.MenuItems.Add(item);
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

        public bool updateItem(Guid id,MenuItem item)
        {
            var num = 0;
            var old = _dataContext.MenuItems.FirstOrDefault(a => a.Id == id);
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
            var item = _dataContext.MenuItems.FirstOrDefault(a => a.Id == id);
            if (item == null) return false;
            try
            {
                _dataContext.MenuItems.Remove(item);
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
