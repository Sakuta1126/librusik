using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace lib
{
    public class BazaDanych
    {
        
            readonly SQLiteAsyncConnection _database;
            public BazaDanych(string db)
            {
                _database = new SQLiteAsyncConnection(db);
                _database.CreateTableAsync<Uczen>().Wait();
                _database.CreateTableAsync<Wynik>().Wait();
                _database.CreateTableAsync<Przedmiot>().Wait();
            }

            public Task<int> DodajUcznia(Uczen uczen)
            {
                return _database.InsertAsync(uczen);
            }

            public Task<List<Uczen>> PobierzUczniow()
            {
                return _database.QueryAsync<Uczen>("SELECT * FROM User");
            }

            public Task<List<Uczen>> PobierzUczniowFiltr(string login, string haslo)
            {
                return _database.QueryAsync<Uczen>("SELECT * FROM User WHERE Login=? AND Password=?", login, haslo);
            }

            public Task<List<Przedmiot>> PobierzPrzedmioty()
            {
                return _database.QueryAsync<Przedmiot>("SELECT * FROM Subject");
            }

            public Task<List<Wynik>> PobierzWyniki()
            {
                return _database.QueryAsync<Wynik>("SELECT * FROM Score");
            }

            public Task<int> DodajPrzedmiot(Przedmiot przedmiot)
            {
                return _database.InsertAsync(przedmiot);
            }

            public Task<int> DodajWynik(Wynik wynik)
            {
                return _database.InsertAsync(wynik);
            }

            public Task<List<Wynik>> PobierzWynik(int uczen_id, int przedmiot_id, string okres)
            {
                return _database.QueryAsync<Wynik>("SELECT * FROM Score WHERE User_id=? AND Subject_id=? AND Period=?", uczen_id, przedmiot_id, okres);
            }
        }
    }

