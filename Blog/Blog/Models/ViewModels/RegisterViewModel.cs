using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
