using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
