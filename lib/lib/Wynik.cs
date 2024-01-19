using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace lib
{
    public  class Wynik
    {
        [PrimaryKey,AutoIncrement]
        public int wynik_id { get; set; }
        public int uczen_id { get; set; }
        public int Przedmiot_id { get; set; }
        public string Przedmiot_nazwa { get; set; }
        public string wartosc { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public string Okres { get; set; }
        

    }
}
