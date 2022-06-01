using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDomain.Entity
{
    [Table("User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int? Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
    }
}
