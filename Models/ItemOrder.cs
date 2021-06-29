using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ItemOrder
    {
        public Guid ItemId { get; set; }
        public Guid OrderId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; } = 1;


    }
}
