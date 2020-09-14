using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper.Excel
{
    class ExcelWorkbook
    {
        public string NewFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(@"C:\Users\graf_\OneDrive\Рабочий стол\C#\Business Helper\Factura.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[0];
              
                worksheet.Cells["A2"].Value = "Счет-фактура № 1 от 14 сентября 2020";
               

                FileInfo xsFile = new FileInfo("C:\\file.xlsx");

                package.SaveAs(xsFile);

                return xsFile.FullName;
            }
        }
    }
}
