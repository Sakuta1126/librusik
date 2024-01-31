using lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
      
        public MainPage()
        {
            InitializeComponent();
           
          
           
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();


           
            var wszystkieWyniki = await App.Bazadanych.Pobierz<Wynik>();

            
            var wynikiUcznia = wszystkieWyniki
                .Where(w => w.uczen_id == ZalogowanyUczen.ZalogowanyUzytkownik.Uczen_id)
                .ToList();


            Wyniki.ItemsSource = wynikiUcznia;
            
            var ocenyUcznia = await App.Bazadanych.Pobierz<Wynik>();
            var ocenyUczniaZalogowanego = ocenyUcznia
                .Where(o => o.uczen_id == ZalogowanyUczen.ZalogowanyUzytkownik.Uczen_id)
                .ToList();

           
            var ocenyOkres1 = ocenyUczniaZalogowanego
                .Where(o => o.Okres.Contains("Okres 1"))
                .ToList();
            var ocenyOkres2 = ocenyUczniaZalogowanego
                .Where(o => o.Okres.Contains("Okres 2"))
                .ToList();

          
            Semestr1.ItemsSource = ocenyOkres1;
            Semestr2.ItemsSource = ocenyOkres2;
      
    }


        private async void Dodaj_Clicked(object sender, EventArgs e)
        {
            if (ZalogowanyUczen.ZalogowanyUzytkownik != null)
            {
                var nazwaPrzedmiotu = Nazwa_przedmiotu.Text;
                var ocenaWartosc = Ocena_wartosc.Text;
                var opis = Opis.Text;


                Wynik nowyWynik = new Wynik
                {
                    uczen_id = ZalogowanyUczen.ZalogowanyUzytkownik.Uczen_id,
                    przedmiot_nazwa = nazwaPrzedmiotu,
                    ocena = ocenaWartosc,
                    Data = DateTime.Now,
                    Opis = opis,
                    Okres = "Okres 2"
                };


                var wynikOperacji = await App.Bazadanych.Dodaj<Wynik>(nowyWynik);


                if (wynikOperacji > 0)
                {
                    await DisplayAlert("Sukces", "Ocena została dodana.", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Błąd", "Nie udało się dodać oceny.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Błąd", "Brak zalogowanego użytkownika.", "OK");

            }
        }
      }
    }
    