using Microsoft.AspNetCore.Mvc;

namespace FindAMovie.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}