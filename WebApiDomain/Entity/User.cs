using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDomain.Entity
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
