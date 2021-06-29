using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class AdminMaster
    {
        public Guid Id { get; set; }
        public string GSTNo { get; set; }
        public double RateSGST { get; set; }
        public double RateCGST { get; set; }

    }
}
