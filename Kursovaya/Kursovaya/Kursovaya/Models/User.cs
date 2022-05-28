using SQLite;

namespace Kursovaya.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string Username { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
