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
        public MenuApplication(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Item> listItems()
        {
            List<Item> list = new List<Item>();
           
            

            try
            {
                list = _dataContext.Items.ToList();
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
                item = _dataContext.Items.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return item;

        }

        public bool createItem(Item item)
        {
            _dataContext.Items.Add(item);
            
            try
            {
               _dataContext.SaveChanges();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
            
                return true;
           
        }

        public bool updateItem(Guid id, Item item)
        {
            var old = _dataContext.Items.FirstOrDefault(a => a.Id == id);
            if (old == null) return false;
            try
            {
                old.IsVeg = item.IsVeg;
                old.Name = item.Name;
                old.Price = item.Price;
                old.Description = item.Description;
                old.Category = item.Category;

                 _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
                return true;
        }

        public bool deleteItem(Guid id)
        {
            var item = _dataContext.Items.FirstOrDefault(a => a.Id == id);
            if (item == null) return false;
            try
            {
                _dataContext.Items.Remove(item);
               _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
                return true;
        }

    }
}
