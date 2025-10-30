using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoMan.Classes
{
    public class CurrencyInfo
    {

        //public int CurrencyIndex; //Название столбца с Индексом
        public string code
        {get;set;}  //Название столбца с кодом "643"
        public string symbol
        { get; set; }  //Название столбца с буквенным кодом "RUB"
        public string name
        { get; set; }  //Название столбца с именем ОКВ "Российский рубль"
        public string country
        { get; set; }  // Краткое наименование стран
    }
}
