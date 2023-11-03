using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        [HttpGet]
      public IActionResult Add()
        {
            return View();
        }
    }
}
