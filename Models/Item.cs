using Newtonsoft.Json;
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
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Int32 Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public bool IsVeg { get; set; }
        public bool Deleted { get; set; } = false;


        [JsonIgnore]
        public virtual ICollection<ItemOrder> ItemOrders { get; set; } 

    }
}
