using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [MinLength(10, ErrorMessage = "Tiêu đề tối thiểu 10 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [MinLength(50, ErrorMessage = "Nội dung tối thiểu 50 ký tự")]
        public string Content { get; set; }

        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Views { get; set; } = 0;
        public string Status { get; set; } = "Công khai";

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public User? Author { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}