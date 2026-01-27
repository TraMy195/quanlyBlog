using Blog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Areas.Editor.Controllers
{
    [Area("Editor")] // ⭐ BẮT BUỘC
    [Authorize(Roles = "Editor")]
    public class ProfileController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProfileController(BlogDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var user = _context.Users
                .Include(u => u.Posts!)
                    .ThenInclude(p => p.Comments)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
                return NotFound();

            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateAvatar(IFormFile avatar)
        {
            if (avatar == null || avatar.Length == 0)
                return RedirectToAction("Index");

            int userId = int.Parse(User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);

            var user = _context.Users.Find(userId);

            string folder = Path.Combine(_env.WebRootPath, "avatars");
            Directory.CreateDirectory(folder);

            string fileName = $"avatar_{userId}{Path.GetExtension(avatar.FileName)}";
            string path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                avatar.CopyTo(stream);
            }

            user.AvatarPath = fileName; // ⭐ chỉ lưu tên file
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateProfile(string fullName, string email, IFormFile? avatar)
        {
            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return NotFound();

            // ===== update text =====
            user.FullName = fullName;
            user.Email = email;

            // ===== update avatar (nếu có) =====
            if (avatar != null && avatar.Length > 0)
            {
                string folder = Path.Combine(_env.WebRootPath, "avatars");
                Directory.CreateDirectory(folder);

                string fileName = $"avatar_{userId}{Path.GetExtension(avatar.FileName)}";
                string path = Path.Combine(folder, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                avatar.CopyTo(stream);

                user.AvatarPath = fileName; // ⭐ chỉ lưu tên file
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }










        public IActionResult Edit()
        {
            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return NotFound();

            return View(user);
        }

    }
}
