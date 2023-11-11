using System.ComponentModel.DataAnnotations;

namespace WebContact.Models
{
    public class ContactViewModel
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? MobilePhone { get; set; }
        [Required]
        public string? JobTitle { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
