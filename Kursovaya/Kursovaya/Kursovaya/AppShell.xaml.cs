using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Kursovaya.Views;
using Kursovaya.Data;
using Kursovaya.Models;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;

namespace Kursovaya
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RestaurantsPage), typeof(RestaurantsPage));
            Routing.RegisterRoute(nameof(DishesPage), typeof(DishesPage));
            Routing.RegisterRoute(nameof(DishPage), typeof(DishPage));
            Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        }
    }
}
