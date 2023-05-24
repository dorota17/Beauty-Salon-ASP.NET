using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonKosmetyczny.Models;
using SalonKosmetyczny.Models.DbModels;

namespace SalonKosmetyczny.Controllers
{
    public class AccountController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Pracownik model)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź poprawność danych logowania
                if (IsValidLogin(model.PracownikId, model.Haslo))
                {
                    // Zalogowano pomyślnie - przekieruj na stronę główną
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Nieprawidłowe dane logowania.");
            }

            return View(model);
        }

        private bool IsValidLogin(int pracownikId, string haslo)
        {
            throw new NotImplementedException();
        }

        private bool IsValidLogin(string pracownikId, string haslo)
        {
            // Tutaj dokonaj walidacji danych logowania
            // Możesz sprawdzić w bazie danych lub innym źródle danych

            // Przykładowa logika walidacji - zakładamy, że ID to "admin" a hasło to "password"
            return pracownikId == "admin" && haslo == "password";
        }

        // ...
    }
}
