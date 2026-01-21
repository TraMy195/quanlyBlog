using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserController : Controller
{
    private readonly BlogDbContext _context;
    public UserController(BlogDbContext context) => _context = context;

    // Hiển thị danh sách người dùng
    public async Task<IActionResult> Index() => View(await _context.Users.ToListAsync());

    // Thêm mới người dùng (Admin tạo)
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}