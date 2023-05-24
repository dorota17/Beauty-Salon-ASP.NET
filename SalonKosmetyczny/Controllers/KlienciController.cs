using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SalonKosmetyczny.Models;
using SalonKosmetyczny.Models.DbModels;

namespace SalonKosmetyczny.Controllers
{
    public class KlienciController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Klienci
        public ActionResult Index()
        {
            return View(db.Klienci.ToList());
        }

        // GET: Klienci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // GET: Klienci/Create
        public ActionResult Create()
        {
            return View(new Klient());
        }

        // POST: Klienci/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlientId,ImieKlienta,NazwiskoKlienta,NumerTelefonu")] Klient klient)
        {
            if(new Regex("^[0-9]{3} [0-9]{3} [0-9]{3}$").IsMatch(klient.NumerTelefonu))
            {
                if (ModelState.IsValid)
                {
                    db.Klienci.Add(klient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Błędny format numeru telefonu";
            }

            return View(klient);
        }

        // GET: Klienci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klienci/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlientId,ImieKlienta,NazwiskoKlienta,NumerTelefonu")] Klient klient)
        {
            //sprawdzanie poprawności numeru telefonu
            if (new Regex("^[0-9]{3} [0-9]{3} [0-9]{3}$").IsMatch(klient.NumerTelefonu))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(klient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Błędny format numeru telefonu";
            }
            return View(klient);
        }

        // GET: Klienci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klienci.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = db.Klienci.Find(id);
            db.Klienci.Remove(klient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
