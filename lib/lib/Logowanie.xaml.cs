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
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {


            var uczniowie = await App.Bazadanych.PobierzUczniowFiltr(Login_Wejscie.Text, Haslo_Wejscie.Text);
            if (Login_Wejscie.Text.Length != 7 || uczniowie.Count == 0)
            {
                DisplayAlert("Blad", "Niepoprawne dane", "OK");
                
                
                return;
            }
        }
    }
}