using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper
{
    public class Summator
    {
        private readonly double _ourSumm;
        private readonly double _stuffSumm;
        public double Count { get; }
        public double Ostatok { get; }

        public Summator(double ourSumm, double stuffSumm)
        {
            _ourSumm = ourSumm;
            _stuffSumm = stuffSumm;
            Count = Math.Floor(_ourSumm / _stuffSumm);
            Ostatok = _ourSumm - (Count * _stuffSumm);
        }             
    }
}