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

        public static string[] GetAllSellers()
        {
            using (var context = new ContextApp())
            {
                
                return context.Sellers.Select(x => x.Name).ToArray();
            }
        }

        public static string[] GetAllCustomers()
        {
            using (var context = new ContextApp())
            {
                return context.Customers.Select(x => x.Name).ToArray();
            }
        }

        public static Seller GetSellerById(int id)
        {
            using (var context = new ContextApp())
            {
                return context.Sellers.FirstOrDefault(x => x.Id == id);
            }
        }

        public static Customer GetCustomerById(int id)
        {
            using (var context = new ContextApp())
            {
                return context.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public static void AddCustomer(Customer customer)
        {
            using (var context = new ContextApp())
            {
                context.Add(customer);
                context.SaveChanges();
            }
        }

        public static void AddSeller(Seller seller)
        {
            using (var context = new ContextApp())
            {
                context.Add(seller);
                context.SaveChanges();
            }
        }

        public static void AddCurrency(Currency currency)
        {
            using (var context = new ContextApp())
            {
                context.Add(currency);
                context.SaveChanges();
            }
        }


        public static string[] GetAllCurrency()
        {
            using (var context = new ContextApp())
            {
                return context.Currencies.Select(x => x.Name).ToArray();
            }
        }
        public static Currency GetCurrencyById(int id)
        {
            using (var context = new ContextApp())
            {
                return context.Currencies.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
