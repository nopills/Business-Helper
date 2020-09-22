using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Helper.EF.Models;

namespace Business_Helper.Excel
{
    class ExcelWorkbook
    {
        public ExcelWorkbook(string examplePath, Seller Seller, Customer Customer)
        {
            _examplePath = examplePath;
            this.Seller = Seller;
            this.Customer = Customer;
  
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        private Seller Seller;
        private Customer Customer;

        private string _examplePath { get; set; }
        public string facturaNumber { get; set; }
        public string facturaDate { get; set; }
        public string payDocumentNumber { get; set; }
        public string payDocumentDate { get; set; }
        public string Currency { get; set; }
        public string currencyCode { get; set; }
      
        public List<Product> Products = new List<Product>();
        
        /*
      

        public string sellerName { get; set; }
        public string sellerAdress { get; set; }
        public string sellerKPP { get; set; }
        public string sellerINN { get; set; }
        public string senderAdress { get; set; }
        
        public string Customer { get; set; }
        public string customerAdress { get; set; }
        public string customerKPP { get; set; }
        public string customerINN { get; set; }
        
        */

        public string CreateFile(string filePath)
        {          
            using (var package = new ExcelPackage(new FileInfo(_examplePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
              
                worksheet.Cells["A2"].Value = $"Счет-фактура № {facturaNumber} от {facturaDate}";
                worksheet.Cells["A4"].Value = $"Продавец: {Seller.Name}\n" +
                    $"Адрес: {Seller.Adress}\n" +
                    $"ИНН / КПП продавца: {Seller.INN} / {Seller.KPP}\n" +
                    $"Грузоотправитель и его адрес: он же\n" +
                    $"К платежно-расчетному документу № {payDocumentNumber} от {payDocumentDate}\n" +
                    $"Покупатель: {Customer.Name}\n" +
                    $"Адрес: {Customer.Adress}\n" +
                    $"ИНН / КПП покупателя: {Customer.INN} / {Customer.KPP}\n" +
                    $"Валюта: наименование, код: {Currency}, {currencyCode}\n" +
                    $"Идентификатор государственного контракта, договора (соглашения) (при наличии):";
                // worksheet.Cells["E9"].Value = $"{Unit.Name}";
                //  worksheet.Cells["G9"].Value = $"{Unit.Code}";
                worksheet.Cells["E9"].Value = $"222";
                worksheet.Cells["E10"].Value = $"223";
                worksheet.Cells["E11"].Value = $"224";
                FileInfo xsFile = new FileInfo(filePath);

                package.SaveAs(xsFile);

                return xsFile.FullName;

            }
        }
    }
}
