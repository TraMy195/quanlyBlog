using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}