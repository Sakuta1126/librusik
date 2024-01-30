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
    public partial class Rejestracja : ContentPage
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
                string login = Login_Wejscie.Text;
                string password = Haslo_Wejscie.Text;
            var existingUser = App.Bazadanych.Pobierz<Uczen>().Result.FirstOrDefault(u => u.Login == login);
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Blad", "Pola nie moga byc puste", "OK");
            }
           else if (existingUser==null &&  Login_Wejscie.Text.Length == 7 && Haslo_Wejscie.Text != string.Empty)
            {
                var newUser = new Uczen { Login = login, Haslo = password};
                App.Bazadanych.Dodaj(newUser);
                DisplayAlert("Information", "Registration complete", "OK");
                Navigation.PushAsync(new Logowanie());
                Login_Wejscie.Text = string.Empty;
                Haslo_Wejscie.Text = string.Empty;
            }
        }
    }
}