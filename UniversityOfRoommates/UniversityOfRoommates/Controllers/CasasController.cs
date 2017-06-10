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
    public class CasasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Casas
        public async Task<ActionResult> Index()
        {
            var casa = db.Case.Include(c => c.Proprietario);
            return View(await casa.ToListAsync());
        }

        // GET: Casas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa casa = await db.Case.FindAsync(id);
            if (casa == null)
            {
                return HttpNotFound();
            }
            return View(casa);
        }

        // GET: Casas/Create
        public ActionResult Create()
        {
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "nick", "iban");
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nomeCasa,longitudine,latitudine,codiceFiscale,provincia,city,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Case.Add(casa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "nick", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // GET: Casas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa casa = await db.Case.FindAsync(id);
            if (casa == null)
            {
                return HttpNotFound();
            }
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "nick", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // POST: Casas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nomeCasa,longitudine,latitudine,codiceFiscale,provincia,city,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "nick", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // GET: Casas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa casa = await db.Case.FindAsync(id);
            if (casa == null)
            {
                return HttpNotFound();
            }
            return View(casa);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Casa casa = await db.Case.FindAsync(id);
            db.Case.Remove(casa);
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
