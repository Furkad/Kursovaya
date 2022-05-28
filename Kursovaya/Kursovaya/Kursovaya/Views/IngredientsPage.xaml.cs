using Kursovaya.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kursovaya.Models;

namespace Kursovaya.Views
{
    [QueryProperty(nameof(ListID), nameof(ListID))]
    public partial class IngredientsPage : ContentPage
    {
        public int globalID;

        public string ListID
        {
            set
            {
                LoadList(value);
            }
        }

        public IngredientsPage()
        {
            InitializeComponent();
        }

        private void LoadList(string value)
        {
            globalID = Convert.ToInt32(value);
        }

        protected override async void OnAppearing()
        {
            List<IngredientList> ingredients = await App.ffDB.GetIngredientListsAsync(globalID);
            List<Ingredient> littleIngredients = new List<Ingredient>();
            foreach (IngredientList ingredient in ingredients)
            {
                littleIngredients.Add(await App.ffDB.GetIngredientAsync(ingredient.Ingredient_ID));
            }
            ingredientsList.ItemsSource = littleIngredients;

            base.OnAppearing();
        }
    }
}