using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
