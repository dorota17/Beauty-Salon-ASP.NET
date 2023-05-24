using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI;
using SalonKosmetyczny.Migrations;
using SalonKosmetyczny.Models;
using SalonKosmetyczny.Models.DbModels;


namespace SalonKosmetyczny.Controllers
{
    public class WizytyController : Controller
    {
        private DatabaseContext db = new DatabaseContext();        

        // GET: Wizyty
        public ActionResult Index()
        {
            var wizyty = db.Wizyty.Include(w => w.Klient).Include(w => w.Pracownik).Include(w => w.Zabieg);
            return View(wizyty.ToList());
        }

        // GET: Wizyty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wizyta wizyta = db.Wizyty.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            return View(wizyta);
        }

        // GET: Wizyty/Create
        public ActionResult Create()
        {
            ViewBag.KlientID = new SelectList(db.Klienci, "KlientId", "DaneKlienta");
            ViewBag.PracownikID = new SelectList(db.Pracownicy, "PracownikId", "DanePracownika");
            ViewBag.ZabiegID = new SelectList(db.Zabiegi, "ZabiegID", "NazwaZabiegu");
            return View(new Wizyta());
        }

        // POST: Wizyty/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WizytaID,DataGodzinaRozpoczecia,KlientID,PracownikID,ZabiegID")] Wizyta wizyta)
        {
            //ustalanie czasu zakończenia wizyty na podstawie czasu trwania zabiegu
            wizyta.DataGodzinaZakonczenia = wizyta.DataGodzinaRozpoczecia.AddMinutes(db.Zabiegi.Single(zabieg => zabieg.ZabiegID == wizyta.ZabiegID).CzasTrwaniaMin);
            //wywołanie funkcji CanAddWizyta w celu sprawdzenia czy można w danym czasie umówić wizytę
            //jeżeli funkcja nie zwróci true to wyświetlany jest komunikat o błędzie
            if(CanAddWizyta(wizyta))
            {
                if (ModelState.IsValid)
                {
                    db.Wizyty.Add(wizyta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Brak dostępnych pracowników";
            }
            ViewBag.KlientID = new SelectList(db.Klienci, "KlientId", "DaneKlienta", wizyta.KlientID);
            ViewBag.PracownikID = new SelectList(db.Pracownicy, "PracownikId", "DanePracownika", wizyta.PracownikID);
            ViewBag.ZabiegID = new SelectList(db.Zabiegi, "ZabiegID", "NazwaZabiegu", wizyta.ZabiegID);
            return View(wizyta);
        }

        //funkcja do sprawdzania czy można dodać wizytę - najpierw sprawdzane jest czy w czasie kiedy chcemy umówić wizytę są już umówione inne wizyty, jeśli tak to ile ich jest i ile jest wtedy wolnych pracowników
        //jeżeli nie ma wolnych pracowników to funkcja zwraca false
        private bool CanAddWizyta(Wizyta wizyta)
        {
            var wizyty_wtedy = db.Wizyty.Where(w => !((w.DataGodzinaRozpoczecia < wizyta.DataGodzinaRozpoczecia && w.DataGodzinaZakonczenia < wizyta.DataGodzinaRozpoczecia) ||
                                                     (w.DataGodzinaZakonczenia > wizyta.DataGodzinaRozpoczecia && w.DataGodzinaZakonczenia > wizyta.DataGodzinaZakonczenia)) &&
                                                     (w.WizytaID != wizyta.WizytaID));
            if(wizyty_wtedy.Count() < db.Pracownicy.Count())
                return true;
            return false;
        }

        // GET: Wizyty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wizyta wizyta = db.Wizyty.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlientID = new SelectList(db.Klienci, "KlientId", "DaneKlienta", wizyta.KlientID);
            ViewBag.PracownikID = new SelectList(db.Pracownicy, "PracownikId", "DanePracownika", wizyta.PracownikID);
            ViewBag.ZabiegID = new SelectList(db.Zabiegi, "ZabiegID", "NazwaZabiegu", wizyta.ZabiegID);
            return View(wizyta);
        }

        // POST: Wizyty/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WizytaID,DataGodzinaRozpoczecia,DataGodzinaZakonczenia,KlientID,PracownikID,ZabiegID")] Wizyta wizyta)
        {
            wizyta.DataGodzinaZakonczenia = wizyta.DataGodzinaRozpoczecia.AddMinutes(db.Zabiegi.Single(zabieg => zabieg.ZabiegID == wizyta.ZabiegID).CzasTrwaniaMin);
            if (CanAddWizyta(wizyta))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(wizyta).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Brak dostępnych pracowników";
            }
            ViewBag.KlientID = new SelectList(db.Klienci, "KlientId", "DaneKlienta", wizyta.KlientID);
            ViewBag.PracownikID = new SelectList(db.Pracownicy, "PracownikId", "DanePracownika", wizyta.PracownikID);
            ViewBag.ZabiegID = new SelectList(db.Zabiegi, "ZabiegID", "NazwaZabiegu", wizyta.ZabiegID);
            return View(wizyta);
        }

        // GET: Wizyty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wizyta wizyta = db.Wizyty.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            return View(wizyta);
        }

        // POST: Wizyty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wizyta wizyta = db.Wizyty.Find(id);
            db.Wizyty.Remove(wizyta);
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
