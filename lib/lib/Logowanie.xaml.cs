using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logowanie : ContentPage
    {
        public Logowanie()
        {
            InitializeComponent();
            dodaj();
        }
        public async void dodaj()
        {
            Uczen uczen = new Uczen()
            {
                Imie = "Michal",
                Nazwisko = "Jedrzejczak",
                Login = "000001n",
                Haslo = "sigma",
                JestNauczycielem = true
            };
            await App.Bazadanych.DodajUcznia(uczen);
            Przedmiot przedmiot = new Przedmiot()
            {
                Przedmiot_nazwa = "matma"
            };
            await App.Bazadanych.DodajPrzedmiot(przedmiot);
            Wynik wynik = new Wynik()
            {
                uczen_id = 1,
                Przedmiot_id = 1,
                Przedmiot_nazwa = "programowanie",
                wartosc = "5+",
                Data = DateTime.Now,
                Opis = "sprawdzian",
                Okres = "okres 1"
            };
            await App.Bazadanych.DodajWynik(wynik);
        }
        private async void Login_Button_Clicked(object sender, EventArgs e)
        {


            var uczniowie = await App.Bazadanych.PobierzUczniowFiltr(Login_Wejscie.Text, Haslo_Wejscie.Text);
            if (Login_Wejscie.Text.Length != 7 || uczniowie.Count == 0)
            {
                DisplayAlert("Blad", "Niepoprawne dane", "OK");
                
                
                return;
            }
            var uczen = uczniowie.ElementAt(0);
            Navigation.PushAsync(new MainPage(uczen));
        }
    }
}