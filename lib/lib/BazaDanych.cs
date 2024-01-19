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

            public Task<int> InsertUser(Uczen uczen)
            {
                return _database.InsertAsync(uczen);
            }

            public Task<List<Uczen>> GetUsers()
            {
                return _database.QueryAsync<Uczen>("SELECT * FROM User");
            }

            public Task<List<Uczen>> GetUserFilter(string login, string password)
            {
                return _database.QueryAsync<Uczen>("SELECT * FROM User WHERE Login=? AND Password=?", login, password);
            }

            public Task<List<Przedmiot>> GetSubjects()
            {
                return _database.QueryAsync<Przedmiot>("SELECT * FROM Subject");
            }

            public Task<List<Wynik>> GetScories()
            {
                return _database.QueryAsync<Wynik>("SELECT * FROM Score");
            }

            public Task<int> InsertSubject(Przedmiot przedmiot)
            {
                return _database.InsertAsync(przedmiot);
            }

            public Task<int> InsertScore(Wynik wynik)
            {
                return _database.InsertAsync(wynik);
            }

            public Task<List<Wynik>> GetScories(int user_id, int subject_id, string period)
            {
                return _database.QueryAsync<Wynik>("SELECT * FROM Score WHERE User_id=? AND Subject_id=? AND Period=?", user_id, subject_id, period);
            }
        }
    }

