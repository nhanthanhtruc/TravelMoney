using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelMoney.Services;
namespace TravelMoney.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void ButtonGoogle_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new GoogleLoginCsPage());
        }
    }
}