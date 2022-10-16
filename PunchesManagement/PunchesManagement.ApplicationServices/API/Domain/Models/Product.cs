using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchesManagement.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Series { get; set; }
        public decimal BatchSize { get; set; }
        public string Description { get; set; }
    }
}
