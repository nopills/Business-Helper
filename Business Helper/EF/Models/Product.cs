using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper.EF.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }
        public string Unit { get; set; }

    }
}
