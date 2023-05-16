using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class JuegosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
