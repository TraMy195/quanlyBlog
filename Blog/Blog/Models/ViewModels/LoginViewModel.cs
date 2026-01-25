using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
