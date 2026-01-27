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
        public IActionResult Index(string? keyword, int? categoryId)
        {
            var query = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Where(p => p.Status == "Công khai");

            // 🔍 Tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p =>
                    p.Title.Contains(keyword) ||
                    p.Content.Contains(keyword));
            }

            // 📂 Lọc theo chuyên mục
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = categoryId;
            ViewBag.Categories = _context.Categories.ToList();

            var posts = query
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
