using progettoSettimanale_mvc2_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettoSettimanale_mvc2_backend.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin a)
        {
            if (ModelState.IsValid)
            {
                Admin authenticatedAdmin = DB.GetAdmin(a);

                if (authenticatedAdmin != null)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            ViewBag.Errore = "Utente non trovato";
            return View();
        }

    }
}
