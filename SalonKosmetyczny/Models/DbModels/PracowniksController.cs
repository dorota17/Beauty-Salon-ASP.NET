using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonKosmetyczny.Models;

namespace SalonKosmetyczny.Models.DbModels
{
    public class PracowniksController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nazwaUzytkownika, string haslo)
        {
            // Sprawdź, czy nazwa użytkownika i hasło są poprawne
            // Jeśli poprawne, uwierzytelnij użytkownika i przekieruj do chronionej części aplikacji
            // W przeciwnym razie wyświetl komunikat o błędzie logowania

            return RedirectToAction("Index", "Home"); // Przekierowanie do chronionej części aplikacji
        }
    }
}
