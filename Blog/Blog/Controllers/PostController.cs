using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PostController : Controller
{
    private readonly BlogDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public PostController(BlogDbContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<IActionResult> Index() => View(await _context.Posts.Include(p => p.Category).ToListAsync());

    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Post post, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            // Xử lý Upload ảnh
            if (imageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                post.ImagePath = fileName;
            }

            post.CreatedAt = DateTime.Now;
            post.Status = "Công khai";
            post.Views = 0;
            // post.AuthorId = ... (Lấy từ Session hoặc Identity)

            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }
}