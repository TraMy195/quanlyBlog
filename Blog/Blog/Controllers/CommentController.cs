using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Controllers
{
    [Authorize] // BẮT BUỘC đăng nhập
    public class CommentController : Controller
    {
        private readonly BlogDbContext _context;

        public CommentController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(int postId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                TempData["Error"] = "Nội dung bình luận không được trống";
                return RedirectToAction("Details", "Home", new { id = postId });
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var comment = new Comment
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Home", new { id = postId });
        }







        [HttpPost]
        [Authorize]
        public IActionResult Edit(int commentId, string content)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var comment = _context.Comments
                .FirstOrDefault(c => c.CommentId == commentId && c.UserId == userId);

            if (comment == null)
                return Forbid();

            comment.Content = content;
            _context.SaveChanges();

            return RedirectToAction("Details", "Home", new { id = comment.PostId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int commentId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var comment = _context.Comments
                .FirstOrDefault(c => c.CommentId == commentId && c.UserId == userId);

            if (comment == null)
                return Forbid();

            int postId = comment.PostId;

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Home", new { id = postId });
        }

    }
}
