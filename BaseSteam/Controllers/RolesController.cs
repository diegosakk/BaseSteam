using BaseSteam.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class RolesController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Roles.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {

            var existe = db.Roles.Any(c => c.Nombre == role.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe un rol con el mismo nombre.";
                return RedirectToAction("Create");
            }

            db.Add(role);
            db.SaveChanges();
            TempData["SuccessMessage"] = "rol creado exitosamente.";

            return RedirectToAction("Create");
        }
        public IActionResult Edit(int? id)
        {
            var role = db.Roles.Find(id);
            if (id != null)
            {
                return View(role);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Role role)
        {
            db.Update(role);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var role = db.Roles.Find(id);
                if (role != null)
                {
                    db.Roles.Remove(role);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}