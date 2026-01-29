using Blog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly BlogDbContext _context;

        public UserController(BlogDbContext context)
        {
            _context = context;
        }

        // 📋 Danh sách user
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        // ================== THÊM USER ==================

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(string username, string email, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError("", "Username đã tồn tại");
                return View();
            }

            var user = new Blog.Models.User
            {
                Username = username,
                Email = email,
                Password = password, // sau này hash
                Role = "Reader",
                IsLocked = false
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ================== ĐỔI QUYỀN (GIỮ NGUYÊN) ==================
        [HttpPost]
        public IActionResult ChangeRole(int userId, string role)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return NotFound();

            user.Role = role;
            _context.SaveChanges();

            TempData["msg"] = "Đã cập nhật quyền";
            return RedirectToAction("Index");
        }

        // ================== KHÓA / MỞ KHÓA ==================
        [HttpPost]
        public IActionResult ToggleLock(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return NotFound();

            user.IsLocked = !user.IsLocked;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Block(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return NotFound();

            user.IsBlocked = true;
            user.IsLocked = true;     // khóa luôn
            user.Role = "Reader";     // hạ quyền

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
