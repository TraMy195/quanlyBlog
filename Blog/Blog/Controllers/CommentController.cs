using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

public class CommentController : Controller
{
    private readonly BlogDbContext _context;
    public CommentController(BlogDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> PostComment(int postId, string content)
    {
        if (string.IsNullOrEmpty(content)) return BadRequest();

        var comment = new Comment
        {
            PostId = postId,
            Content = content,
            CreatedAt = DateTime.Now,
            UserId = 1 // Giả định ID user đã đăng nhập
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details", "Home", new { id = postId });
    }
}