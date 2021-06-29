using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    public class Request
    {
        public Guid [] ids { get; set; }
        public OrderDto orderDto { get; set; }
    }
}
