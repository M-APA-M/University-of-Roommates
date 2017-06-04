using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityOfRoommates.Models;

namespace UniversityOfRoommates.Controllers
{
    public class UtenteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Utente
        public async Task<ActionResult> Index()
        {
            var utenti = db.Utenti.Include(u => u.Interesse);
            return View(await utenti.ToListAsync());
        }

        // GET: Utente/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utente utente = await db.Utenti.FindAsync(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            return View(utente);
        }

        // GET: Utente/Create
        public ActionResult Create()
        {
            ViewBag.codiceFiscale = new SelectList(db.Interessi, "codiceFiscale", "p1");
            return View();
        }

        // POST: Utente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codiceFiscale,nome,cognome,sesso,ddn,cittàProvenienza,email,cell,idInteresse")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                db.Utenti.Add(utente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codiceFiscale = new SelectList(db.Interessi, "codiceFiscale", "p1", utente.codiceFiscale);
            return View(utente);
        }

        // GET: Utente/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utente utente = await db.Utenti.FindAsync(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            ViewBag.codiceFiscale = new SelectList(db.Interessi, "codiceFiscale", "p1", utente.codiceFiscale);
            return View(utente);
        }

        // POST: Utente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codiceFiscale,nome,cognome,sesso,ddn,cittàProvenienza,email,cell,idInteresse")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codiceFiscale = new SelectList(db.Interessi, "codiceFiscale", "p1", utente.codiceFiscale);
            return View(utente);
        }

        // GET: Utente/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utente utente = await db.Utenti.FindAsync(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            return View(utente);
        }

        // POST: Utente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Utente utente = await db.Utenti.FindAsync(id);
            db.Utenti.Remove(utente);
            await db.SaveChangesAsync();
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
