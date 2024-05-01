using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ContactManagement.Attributes;

namespace ContactManagement.Models
{
    [Table("Customers")]
    public class ContactModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string? Name { get; set; }

        [Column("contact")]
        [Required]
        [NineDigitsPhoneNumber]
        public string? Contact { get; set; }

        [Column("email")]
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not in a valid format.")]
        [UniqueEmail(ErrorMessage = "Este e-mail já está em uso.")]
        public string? Email { get; set; }
    }
}
