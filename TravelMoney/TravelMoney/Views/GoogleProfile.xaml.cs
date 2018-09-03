using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMoney.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMoney.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GoogleProfile : ContentPage
	{
        private User user { get; set; }
        public GoogleProfile (UserProfileGoogle userProfile)
		{
			InitializeComponent ();
            user = new User() { Name = userProfile.DisplayName,Image=userProfile.Image.Url};
            BindingContext = userProfile;

        }
        public GoogleProfile()
        {
            InitializeComponent();            
        }
    }
}