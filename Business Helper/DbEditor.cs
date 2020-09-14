using Business_Helper.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper
{
    public static class DbEditor
    {
        public static void AddItem(string Name, double Price, double VAT, string Unit)
        {
            using (var context = new ContextApp())
            {
                context.Add(
                    new Product
                    {
                        Name = Name,
                        Price = Price,
                        VAT = VAT,
                        Unit = Unit
                    });
                context.SaveChanges();
            }
        }

        public static void AddUnit(string Name)
        {
            using (var context = new ContextApp())
            {
                context.Add(
                    new Unit
                    {
                        Name = Name,                      
                    });
                context.SaveChangesAsync();
            }
        }

        public static string[] GetAllItems()
        {
            using (var context = new ContextApp())
            {    
                 return context.Products.Select(x => x.Name).ToArray();                           
            }
        }

        public static (double, double, string) GetItem(string Name)
        {
            double Price = default;
            double VAT = default;
            string Unit = String.Empty;

            using (var context = new ContextApp())
            {
                var res = context.Products.Where(x => x.Name == Name).Select(a => new { prc = a.Price, unt = a.Unit, vat = a.VAT } );
                foreach (var a in res)
                {
                    Price = a.prc;
                    VAT = a.vat;
                    Unit = a.unt;
                }
                return (Price, VAT, Unit);
            }
           
            
        }
        public static string[] GetAllUnits()
        {
            using (var context = new ContextApp())
            {
                return context.Units.Select(x => x.Name).ToArray();
            }
        }
    }
}
