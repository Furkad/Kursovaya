using SQLite;

namespace Kursovaya.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int ID { get; set; }
        [Unique]
        public string Name { get; set; }
    }
}
