using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Kursovaya.Models;
using System.IO;
using System;

namespace Kursovaya.Data
{
    public class FFDB
    {
        SQLiteAsyncConnection db;
        public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FFDB.db");

        //конструктор
        public FFDB()
        {
            db = new SQLiteAsyncConnection(dbPath);

            db.CreateTableAsync<Ingredient>().Wait();
            db.CreateTableAsync<Dish>().Wait();
            db.CreateTableAsync<IngredientList>().Wait();
            db.CreateTableAsync<Restaurant>().Wait();
            db.CreateTableAsync<User>().Wait();
        }

        //методы, связанные с ингредиентами
        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
             return await db.Table<Ingredient>().ToListAsync();
        }

        public async Task<Ingredient> GetIngredientAsync(int id)
        {
             return await db.Table<Ingredient>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveIngredientAsync(Ingredient ingredient)
        {
            if (ingredient.ID != 0)
                return await db.UpdateAsync(ingredient);
            else
                return await db.InsertAsync(ingredient);
        }

        public async Task<int> DeleteIngredientAsync(Ingredient ingredient)
        {
            return await db.DeleteAsync(ingredient);
        }
        /////

        /////методы, связанные с блюдами
        public async Task<List<Dish>> GetDishesAsync()
        {
            return await db.Table<Dish>().ToListAsync();
        }

        public async Task<List<Dish>> GetDishesAsync(int id)
        {
            return await db.Table<Dish>().Where(i => i.Restaurant == id).ToListAsync();
        }

        public async Task<Dish> GetDishAsync(int id)
        {
            return await db.Table<Dish>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveDishAsync(Dish dish)
        {
            if (dish.ID != 0)
                return await db.UpdateAsync(dish);
            else
                return await db.InsertAsync(dish);
        }

        public async Task<int> DeleteDishAsync(Dish dish)
        {
            return await db.DeleteAsync(dish);
        }
        /////
        
        /////методы, связанные со списками ингредиентов
        public async Task<List<IngredientList>> GetIngredientListsAsync()
        {
            return await db.Table<IngredientList>().ToListAsync();
        }

        public async Task<List<IngredientList>> GetIngredientListsAsync(int id)
        {
            return await db.Table<IngredientList>().Where(i => i.Dish_ID == id).ToListAsync();
        }

        public async Task<IngredientList> GetIngredientListAsync(int id)
        {
            return await db.Table<IngredientList>().Where(i => i.Dish_ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveIngredientListAsync(IngredientList ingredientList)
        {
            if (ingredientList.Dish_ID != 0)
                return await db.UpdateAsync(ingredientList);
            else
                return await db.InsertAsync(ingredientList);
        }

        public async Task<int> DeleteIngredientListAsync(IngredientList ingredientList)
        {
            return await db.DeleteAsync(ingredientList);
        }
        /////

        /////методы, связанные с ресторанами
        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await db.Table<Restaurant>().ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
            return await db.Table<Restaurant>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant.ID != 0)
                return await db.UpdateAsync(restaurant);
            else
                return await db.InsertAsync(restaurant);
        }

        public async Task<int> DeleteRestaurantAsync(Restaurant restaurant)
        {
            return await db.DeleteAsync(restaurant);
        }
        /////
        /////методы, связанные с ресторанами
        public async Task<List<User>> GetUsersAsync()
        {
            return await db.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await db.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
                return await db.UpdateAsync(user);
            else
                return await db.InsertAsync(user);
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            return await db.DeleteAsync(user);
        }
        /////
    }
}
