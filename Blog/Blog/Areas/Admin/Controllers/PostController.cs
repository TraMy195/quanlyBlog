using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
