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
           
        }

        

    
    }
}