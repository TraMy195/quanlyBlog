using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string? CurrentAvatar { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
