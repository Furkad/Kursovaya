using SQLite;

namespace Kursovaya.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Cuisine { get; set; }
    }
}
