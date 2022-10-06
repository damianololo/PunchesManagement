using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchesManagement.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Series { get; set; }
        public decimal BatchSize { get; set; }
        public string Description { get; set; }
    }
}
