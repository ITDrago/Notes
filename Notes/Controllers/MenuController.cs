using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
