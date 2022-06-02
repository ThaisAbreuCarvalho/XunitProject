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

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Document")]
        public string Document { get; set; }

        [Column("AddressId")]
        public string AddressId { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
