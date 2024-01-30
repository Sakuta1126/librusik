using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static lib.BazaDanych;

namespace lib
{
    public partial class App : Application
    {
        static BazaDanych bazadanych;

        public static BazaDanych Bazadanych
        {
            get
            {
                if (bazadanych == null)
                {
                    bazadanych = new BazaDanych(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lib.db3"));
                }
                return bazadanych;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Rejestracja());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
