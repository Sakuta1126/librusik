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

          public Task<int> Dodaj<T>(T item)
        {
            return _database.InsertAsync(item);
        }

           

        public Task<List<T>> Pobierz<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

           


            
        }
    }

