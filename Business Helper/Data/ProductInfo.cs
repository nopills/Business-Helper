using Business_Helper.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper.Data
{
    public class ProductInfo
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public string vatSumm { get; set; }
        public string summWithVat { get; set; }
    }
}
