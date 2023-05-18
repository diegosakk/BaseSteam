using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BaseSteam.Controllers
{
    public class UsuarioController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.IdRolesNavigation);
            ;
            return View(usuarios);
        }
        public IActionResult Create()
        {

            ViewData["IdRoles"] = new SelectList(db.Roles, "Id", "Nombre");


            return View();

        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {

            var existe = db.Usuarios.Any(c => c.Nombre == usuario.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe un usuario con el mismo nombre.";
                return RedirectToAction("Create");
            }

            db.Add(usuario);
            db.SaveChanges();
            TempData["SuccessMessage"] = "usuario creado exitosamente.";

            return RedirectToAction("Create");
        }
        public IActionResult Edit(int? id)
        {
            ViewData["IdRoles"] = new SelectList(db.Roles, "Id", "Nombre");
            var usuario = db.Usuarios.Find(id);
            if (id != null)
            {
                return View(usuario);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            ViewData["IdRoles"] = new SelectList(db.Roles, "Id", "Nombre");
            var existe = db.Usuarios.Any(c => c.Nombre == usuario.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe un usuario con el mismo nombre.";
                return RedirectToAction("Edit");
            }

            db.Update(usuario);
            db.SaveChanges();
            TempData["SuccessMessage"] = "usuario modificiado exitosamente.";

            return RedirectToAction("Edit");
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