using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Areas.Editor.Controllers
{
    [Area("Editor")]
    [Authorize(Roles = "Editor,Admin")]
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PostController(BlogDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // 📌 Danh sách bài của tôi
        public IActionResult Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var posts = _context.Posts
                .Include(p => p.Category)
                .Where(p => p.AuthorId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(posts);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                post.AuthorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                post.CreatedAt = DateTime.Now;
                post.Views = 0;
                post.Status = "Công khai";

                // Upload ảnh
                if (image != null && image.Length > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    string path = Path.Combine(_env.WebRootPath, "images", fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    image.CopyTo(stream);

                    post.ImagePath = fileName;
                }

                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(post);
        }

        // ================= EDIT =================
        public IActionResult Edit(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var post = _context.Posts.FirstOrDefault(p => p.PostId == id && p.AuthorId == userId);
            if (post == null) return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post, IFormFile? image)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var oldPost = _context.Posts.AsNoTracking()
                .FirstOrDefault(p => p.PostId == id && p.AuthorId == userId);

            if (oldPost == null) return NotFound();

            if (ModelState.IsValid)
            {
                post.AuthorId = userId;
                post.CreatedAt = oldPost.CreatedAt;
                post.Views = oldPost.Views;

                if (image != null && image.Length > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    string path = Path.Combine(_env.WebRootPath, "images", fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    image.CopyTo(stream);

                    post.ImagePath = fileName;
                }
                else
                {
                    post.ImagePath = oldPost.ImagePath;
                }

                _context.Posts.Update(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(post);
        }

        // ================= DELETE =================
        public IActionResult Delete(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var post = _context.Posts
                .FirstOrDefault(p => p.PostId == id && p.AuthorId == userId);

            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
