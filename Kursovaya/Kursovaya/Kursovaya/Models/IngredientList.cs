using SQLite;
using SQLitePCL;

namespace Kursovaya.Models
{
    [Table("IngredientList")]
    public class IngredientList
    {
        [NotNull]
        public int Dish_ID { get; set; }      
        public int Ingredient_ID { get; set; }
    }
}
