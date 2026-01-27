using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class EditorController : Controller
    {
        private readonly BlogDbContext _context;

        public EditorController(BlogDbContext context)
        {
            _context = context;
        }

        // /Editor/Profile/5
        public IActionResult Profile(int id)
        {
            var editor = _context.Users
                .Include(u => u.Posts!)
                .ThenInclude(p => p.Category)
                .FirstOrDefault(u => u.UserId == id && u.Role == "Editor");

            if (editor == null)
                return NotFound();

            return View(editor);
        }
    }
}
