using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
