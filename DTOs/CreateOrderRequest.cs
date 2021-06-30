using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    public class CreateOrderRequest
    {
        [Required]
        public Guid [] Ids { get; set; }
        [Required]
        public OrderDto OrderDto { get; set; }
    }
}
