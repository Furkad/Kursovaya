using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kursovaya.Models;

namespace Kursovaya.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            List<User> logers = await App.ffDB.GetUsersAsync();
            bool isExisting = false;
            foreach (User user in logers)
            {
                if (user.Username == login.Text && user.Password == password.Text)
                {
                    isExisting = true;
                    break;
                }
            }
            if (isExisting)
                await Shell.Current.GoToAsync(nameof(RestaurantsPage));
            else
                await DisplayAlert("ERROR", "Invalid Login or Password", "OK");
        }
    }
}