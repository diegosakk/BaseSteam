using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaseSteam.Controllers
{
    public class UsuarioController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.RolesNavigation);
            return View(usuarios);
        }
        public IActionResult Create()
        {
            ViewData["Rolesss"] = new SelectList(db.Roles, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
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