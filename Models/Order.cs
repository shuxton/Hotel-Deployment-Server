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
        public Guid Id { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public bool IsParcel { get; set; }
        public double Total { get; set; }
        public double GrandTotal { get; set; }
        public double Discount { get; set; }
        public double Others { get; set; }
        public double CGST { get; set; } 
        public double SGST { get; set; } 

        public int OrderNo { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }


        public virtual ICollection<ItemOrder> ItemOrders { get; set; }
    }
}
