using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using Kursovaya.Models;

namespace Kursovaya.Views
{
    public partial class RestaurantsPage : ContentPage
    {
        public RestaurantsPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            restaurantsView.ItemsSource = await App.ffDB.GetRestaurantsAsync();
            base.OnAppearing();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Restaurant restaurant = (Restaurant)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(DishesPage)}?{nameof(DishesPage.ItemID)}={restaurant.ID.ToString()}");
            }
        }
    }
}