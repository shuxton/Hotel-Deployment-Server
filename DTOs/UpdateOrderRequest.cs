using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    public class UpdateOrderRequest
    {
       
        [Required]

        public string Status { get; set; }

        [Required]
        public bool Paid { get; set; }

    }
}
