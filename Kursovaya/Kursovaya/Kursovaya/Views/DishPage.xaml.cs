using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kursovaya.Data;
using Kursovaya.Models;
using System.Reflection;
using System.IO;

namespace Kursovaya.Views
{
    [QueryProperty(nameof(ItemID), nameof(ItemID))]
    public partial class DishPage : ContentPage
    {
        int globalID;
        public string ItemID
        {
            set
            {
                LoadInfo(value);
            }
        }

        private void LoadInfo(string value)
        {
            globalID = Convert.ToInt32(value);
        }

        public DishPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = await App.ffDB.GetDishAsync(globalID);
            Dish currentDish = (Dish)BindingContext;
            Restaurant currentRestaurant = await App.ffDB.GetRestaurantAsync(currentDish.Restaurant);

            image.Source = ImageSource.FromResource($"Kursovaya.Images.{currentRestaurant.Name}_{currentDish.Name}.png");

        }

        
        /*private async void Favorite_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Dish currentDish = (Dish)BindingContext;
            if (isFavorite.IsChecked)
                currentDish.Favorite = 1;
            else
                currentDish.Favorite = 0;
            await App.ffDB.SaveDishAsync(currentDish);
        }*/

        private async void IngredientsClicked(object sender, EventArgs e)
        {
            Dish currentDish = (Dish)BindingContext;
            IngredientList ingredientList = await App.ffDB.GetIngredientListAsync(currentDish.ID);

            await Shell.Current.GoToAsync($"{nameof(IngredientsPage)}?{nameof(IngredientsPage.ListID)}={currentDish.ID.ToString()}");
        }
    }
}