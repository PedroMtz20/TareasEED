using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaBuena
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasStickers : ContentPage
	{
		public MasStickers ()
		{
			InitializeComponent ();
		}

        public void cambiarMisStickers_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
	}
}