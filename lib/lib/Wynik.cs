using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace lib
{
    public  class Wynik
    {
        [PrimaryKey,AutoIncrement]
        public int Wynik_id { get; set; }
        public int uczen_id { get; set; }
        public int przedmiot_id { get; set; }
        public string przedmiot_nazwa { get; set; }
        public string ocena { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public string Okres { get; set; }
        

    }
}
