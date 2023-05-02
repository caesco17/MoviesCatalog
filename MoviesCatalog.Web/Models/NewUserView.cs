using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Web.Models
{
    public class NewUserView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
