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
        
        private const double oneHundredPercent = 100;

        public CalculateVAT(double itemPrice, double vatPercent)
        {
            _itemPrice = itemPrice;
            _vatPercent = vatPercent;
        }
    
        public double priceWithoutVat()
        {
            //Выделить НДС (Цена товара * 100% / 100% + НДС)
            double result = (oneHundredPercent * _itemPrice) / (oneHundredPercent + _vatPercent);
            return result;
        }

        public double vatSumm()
        {
            //НДС составляет: (Цена товара * НДС) / 100% + НДС 
            double result = (_itemPrice * _vatPercent) / (oneHundredPercent + _vatPercent);
            return result;
        }
    }
}
