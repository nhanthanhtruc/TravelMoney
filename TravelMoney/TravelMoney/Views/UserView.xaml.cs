using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMoney.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMoney.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentPage
    {
        public static ObservableCollection<User> user { get; set; }
        public UserView()
        {
            InitializeComponent();
            if (user == null)
            {
                user = new ObservableCollection<User>()
                {
                    new User()
                    {
                        Name="Nhan Thanh Trúc",
                        Female=true,
                        Email="nhanthanhtruc@gmail.com",
                        Online=false,
                        Default=true
                    },
                    new User()
                    {
                        Name="Dương Đình Hữu",
                        Female=false,
                        Email="nhanthanhtruc@gmail.com",
                        Online=false,
                        Default=true
                    }
                };
            };
            ListViewUser.ItemsSource = user;
        }
        public void OnMore(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserDetail());
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var bindingContext = ((MenuItem)sender).BindingContext;
            var DeleteUser = (User)bindingContext;
            if (await DisplayAlert("Delete User", "Are you sure?", "OK", "Cancel"))
            {
                user.Remove(DeleteUser);
            }
        }
    }
}
