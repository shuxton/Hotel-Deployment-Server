using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime time { get; set; } = new DateTime();
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
