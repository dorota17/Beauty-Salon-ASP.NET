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
    public class ZabiegiController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Zabiegi
        public ActionResult Index()
        {
            return View(db.Zabiegi.ToList());
        }

        // GET: Zabiegi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zabieg zabieg = db.Zabiegi.Find(id);
            if (zabieg == null)
            {
                return HttpNotFound();
            }
            return View(zabieg);
        }

        // GET: Zabiegi/Create
        public ActionResult Create()
        {
            return View(new Zabieg());
        }

        // POST: Zabiegi/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZabiegID,NazwaZabiegu,CzasTrwaniaMin,Cena")] Zabieg zabieg)
        {
            if (ModelState.IsValid)
            {
                db.Zabiegi.Add(zabieg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zabieg);
        }

        // GET: Zabiegi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zabieg zabieg = db.Zabiegi.Find(id);
            if (zabieg == null)
            {
                return HttpNotFound();
            }
            return View(zabieg);
        }

        // POST: Zabiegi/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZabiegID,NazwaZabiegu,CzasTrwaniaMin,Cena")] Zabieg zabieg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zabieg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zabieg);
        }

        // GET: Zabiegi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zabieg zabieg = db.Zabiegi.Find(id);
            if (zabieg == null)
            {
                return HttpNotFound();
            }
            return View(zabieg);
        }

        // POST: Zabiegi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zabieg zabieg = db.Zabiegi.Find(id);
            db.Zabiegi.Remove(zabieg);
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
