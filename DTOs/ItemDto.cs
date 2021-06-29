using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    public class ItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Int32 Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsVeg { get; set; }

        [Required]
        public string Category { get; set; }

    }
}
