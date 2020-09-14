using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Helper.EF.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //Имя компании
        public string Name { get; set; }
        //ИНН
        public string INN { get; set; }
        //КПП
        public string KPP { get; set; }
        //Адрес
        public string Adress { get; set; }
        //Грузоотправитель
        public string Sender { get; set; }
        //Расчетный счет
        public string CheckingAcc { get; set; }
        //БИК
        public string BIK { get; set; }
        //Название Банка
        public string BankName { get; set; }
        //Корп. счёт
        public string CorpAcc { get; set; }
    }
}
