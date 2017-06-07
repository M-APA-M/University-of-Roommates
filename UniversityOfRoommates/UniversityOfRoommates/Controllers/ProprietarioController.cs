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
    public class ProprietarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proprietario
        public async Task<ActionResult> Index()
        {
            var proprietari = db.Proprietari.Include(p => p.Utente);
            return View(await proprietari.ToListAsync());
        }

        // GET: Proprietario/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietari.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        // GET: Proprietario/Create
        public ActionResult Create()
        {
            ViewBag.codiceFiscale = new SelectList(db.Utenti, "codiceFiscale", "nome");
            return View();
        }

        // POST: Proprietario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codiceFiscale,iban,paypalMe,cartaIdentità")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Proprietari.Add(proprietario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codiceFiscale = new SelectList(db.Utenti, "codiceFiscale", "nome", proprietario.codiceFiscale);
            return View(proprietario);
        }

        // GET: Proprietario/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietari.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            ViewBag.codiceFiscale = new SelectList(db.Utenti, "codiceFiscale", "nome", proprietario.codiceFiscale);
            return View(proprietario);
        }

        // POST: Proprietario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codiceFiscale,iban,paypalMe,cartaIdentità")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codiceFiscale = new SelectList(db.Utenti, "codiceFiscale", "nome", proprietario.codiceFiscale);
            return View(proprietario);
        }

        // GET: Proprietario/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietari.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        // POST: Proprietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Proprietario proprietario = await db.Proprietari.FindAsync(id);
            db.Proprietari.Remove(proprietario);
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
