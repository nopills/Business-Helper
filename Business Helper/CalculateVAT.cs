using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper
{
    public class CalculateVAT
    {
        private readonly double _itemPrice;
        private readonly double _vatPercent;
        private readonly int _mode;
        
        private const double oneHundredPercent = 100;

        private double vatSumm { get; set; }

        public CalculateVAT(double itemPrice, double vatPercent, int mode)
        {
            _itemPrice = itemPrice;
            _vatPercent = vatPercent;
            _mode = mode;
        }
    
        public double priceWithoutVat()
        {
            double result = 0;
            switch (_mode)
            {
                case 1:
                    //Выделить НДС (Цена товара * 100% / 100% + НДС)
                    result = (oneHundredPercent * _itemPrice) / (oneHundredPercent + _vatPercent);
                    //НДС составляет: (Цена товара * НДС) / 100% + НДС   
                    vatSumm = (_itemPrice * _vatPercent) / (oneHundredPercent + _vatPercent);
                    break;
               // case 0:
                    //Начислить НДС ()
                   // result = (oneHundredPercent * _itemPrice) / (oneHundredPercent + _vatPercent);
                   // break;
            }
            return result;
        }

        public double checkVatSumm()
        {                    
            return vatSumm;
        }
    }
}
