using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseSteam.Controllers
{
    public class UsuarioController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            var usuario = db.Usuarios.Include(p => p.IdRolesNavigation);
            return View(db.Roles.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            db.Add(usuario);
            db.SaveChanges();
            //return View();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            var usuario = db.Roles.Find(id);
            if (id != null)
            {
                return View(usuario);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            db.Update(usuario);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}