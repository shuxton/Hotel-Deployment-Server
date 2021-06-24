using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Int32 Price { get; set; }

        public string Description { get; set; }

        public bool IsVeg { get; set; }

        public string Image { get; set; }

    }
}
