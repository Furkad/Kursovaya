using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kursovaya.Models;
using Kursovaya.Data;

namespace Kursovaya.Views
{
    [QueryProperty(nameof(ItemID), nameof(ItemID))]
    public partial class DishesPage : ContentPage
    {
        public int globalID;

        public string ItemID
        {
            set
            {
                LoadInfo(value);
            }
        }
        public DishesPage()
        {
            InitializeComponent();
        }

        private void LoadInfo(string value)
        {
            globalID = Convert.ToInt32(value);
        }

        protected override async void OnAppearing()
        {
            DishesView.ItemsSource = await App.ffDB.GetDishesAsync(globalID);

            base.OnAppearing();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Dish dish = (Dish)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(DishPage)}?{nameof(DishPage.ItemID)}={dish.ID.ToString()}");
            }

        }
    }
}