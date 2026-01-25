using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _context;

        public HomeController(BlogDbContext context)
        {
            _context = context;
        }

        // ===== TRANG CHỦ =====
        public IActionResult Index()
        {
            var posts = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Where(p => p.Status == "Công khai")
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(posts);
        }

        // ===== CHI TIẾT BÀI VIẾT =====
        public IActionResult Details(int id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .FirstOrDefault(p => p.PostId == id);

            if (post == null)
                return NotFound();

            // Tăng lượt xem
            post.Views++;
            _context.SaveChanges();

            return View(post);
        }
    }
}
