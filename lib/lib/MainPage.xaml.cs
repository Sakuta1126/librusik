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
        Uczen uczen;
        public MainPage(Uczen uczen)
        {
            InitializeComponent();
           
            this.uczen = uczen;
            ZaladujDane();
        }

        

        public async void ZaladujDane()
        {
            Wyniki.ItemsSource = await App.Bazadanych.PobierzWyniki();

            List<List<string>> semestr1 = new List<List<string>>();
            List<List<string>> semestr2 = new List<List<string>>();

            var przedmioty = await App.Bazadanych.PobierzPrzedmioty();
            foreach (var przedmiot in przedmioty)
            {
                List<string> row = new List<string>();

                var scoriesPeriodOne = await App.Bazadanych.PobierzWynik(this.uczen.Uczen_id, przedmiot.Przedmiot_id, "Okres 1");
                string scoriesPeriodOneText = "";
                foreach (var score in scoriesPeriodOne)
                {
                    scoriesPeriodOneText += score.wartosc + " ";
                }
                row.Add(scoriesPeriodOneText);
                row.Add(przedmiot.Przedmiot_nazwa);

                semestr1.Add(row);
            }

            foreach (var przedmiot in przedmioty)
            {
                List<string> row = new List<string>();

                var scoriesPeriodTwo = await App.Bazadanych.PobierzWynik(this.uczen.Uczen_id, przedmiot.Przedmiot_id, "Okres 2");
                string scoriesPeriodTwoText = "";
                foreach (var score in scoriesPeriodTwo)
                {
                    scoriesPeriodTwoText += score.wartosc + " ";
                }
                row.Add(scoriesPeriodTwoText);
                row.Add(przedmiot.Przedmiot_nazwa);

                semestr1.Add(row);
            }

            Semestr1.ItemsSource = semestr1;
            Semestr2.ItemsSource = semestr2;
        }
    }
}