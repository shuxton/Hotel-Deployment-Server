using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    public class OrderDto
    {
        [Required]
        public bool IsParcel { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public double Others { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
    }
}
