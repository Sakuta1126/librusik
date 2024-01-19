using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib
{
    public class Przedmiot
    {
        [AutoIncrement, PrimaryKey]
        public int Wynik_id { get; set; }
        public int Uczen_id { get; set; }
        public int Przedmiot_id { get; set; }
        public string Przedmiot_nazwa { get; set; }
        public string Wartosc { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public string Okres { get; set; }
    }
}
