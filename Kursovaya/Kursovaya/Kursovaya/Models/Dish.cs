using SQLite;

namespace Kursovaya.Models
{
    [Table("Dish")]
    public class Dish
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int ID { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public int Restaurant { get; set; }
        [NotNull]
        public string Country { get; set; }
        [NotNull]
        public float Price { get; set; }
        [NotNull]
        public float Weight { get; set; }
        [NotNull]
        public float Calories { get; set; }
        [NotNull]
        public int Favorite { get; set; }
    }
}
