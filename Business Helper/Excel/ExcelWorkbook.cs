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
using Business_Helper.Data;

namespace Business_Helper.Excel
{
    class ExcelWorkbook
    {
       
        public ExcelWorkbook(string examplePath, Seller Seller, Customer Customer, List<ProductInfo> Products)
        {            
            _examplePath = examplePath;
            this.Seller = Seller;
            this.Customer = Customer;       
            this.Products = Products;
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        
        private Seller Seller;
        private Customer Customer;
        private List<ProductInfo> Products;
       
        private string _examplePath { get; set; }
        public string facturaNumber { get; set; }
        public string facturaDate { get; set; }
        public string payDocumentNumber { get; set; }
        public string payDocumentDate { get; set; }
        public string Currency { get; set; }
        public string currencyCode { get; set; }
      
        
        
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
                worksheet.Cells.Style.Font.Size = 7;
                worksheet.Cells.Style.Font.Name = "Arial";
               

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
                
                int cellsCounter = 8;
                
                for(int i = 0; i < Products.Count; i++)
                {
                    cellsCounter++;
                    worksheet.Row(cellsCounter).Height = 15;

                    worksheet.Cells["A" + cellsCounter + ":C" + cellsCounter].Merge = true;                  
                    worksheet.Cells["A"+(cellsCounter)].Value = Products[i].Product.Name;               
                    worksheet.Cells["E"+ cellsCounter].Value = Products[i].Product.UnitCode;
                    worksheet.Cells["E"+ cellsCounter+":F"+ cellsCounter].Merge = true;
                    worksheet.Cells["G"+ cellsCounter].Value = Products[i].Product.UnitName;
                    worksheet.Cells["H"+ cellsCounter].Value = Products[i].Count;
                    worksheet.Cells["I"+ cellsCounter].Value = Products[i].summWithoutVat;
                    worksheet.Cells["J"+ cellsCounter].Value = Products[i].summWithoutVat;
                    worksheet.Cells["J"+ cellsCounter+":K"+ cellsCounter].Merge = true;
                    worksheet.Cells["L"+ cellsCounter].Value = "без акциза";
                    worksheet.Cells["M"+cellsCounter].Value = Products[i].Product.VAT + "%";
                    worksheet.Cells["N"+cellsCounter].Value = Products[i].vatSumm;
                    worksheet.Cells["N"+ cellsCounter+":O"+cellsCounter].Merge = true;
                    worksheet.Cells["P"+cellsCounter].Value = Products[i].summWithVat;
                    worksheet.Cells["Q"+cellsCounter].Value = "---";
                    worksheet.Cells["Q"+ cellsCounter+":S"+cellsCounter].Merge = true;
                    worksheet.Cells["T"+cellsCounter].Value = "---";
                    worksheet.Cells["U"+cellsCounter].Value = "---";

                    worksheet.Cells["A" + cellsCounter + ":U" + cellsCounter].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + cellsCounter + ":U" + cellsCounter].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + cellsCounter + ":U" + cellsCounter].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + cellsCounter + ":U" + cellsCounter].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    //worksheet.Cells["A" + cellsCounter + ":C" + cellsCounter].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

               
               


                    FileInfo xsFile = new FileInfo(filePath);

                package.SaveAs(xsFile);

                return xsFile.FullName;

            }
        }
    }
}
