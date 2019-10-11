using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaBuena
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void cambiarMasStickers_Clicked()
        {
            Navigation.PushAsync(new MasStickers());
        }
    }
}
