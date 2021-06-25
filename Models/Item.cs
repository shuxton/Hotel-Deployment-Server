using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public Int32 Price { get; set; }

        public string Description { get; set; }

        public bool IsVeg { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
