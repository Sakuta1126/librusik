using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib
{
    public class Uczen
    {
        [PrimaryKey, AutoIncrement]
        public int Uczen_id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public bool JestNauczycielem { get; set; }
    }
}
