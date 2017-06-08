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
    public class GestioneCasasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GestioneCasas
        public async Task<ActionResult> Index()
        {
            var gestioneCase = db.GestioneCase.Include(g => g.Casa);
            return View(await gestioneCase.ToListAsync());
        }

        // GET: GestioneCasas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestioneCasa gestioneCasa = await db.GestioneCase.FindAsync(id);
            if (gestioneCasa == null)
            {
                return HttpNotFound();
            }
            return View(gestioneCasa);
        }

        // GET: GestioneCasas/Create
        public ActionResult Create()
        {
            ViewBag.nomeCasa = new SelectList(db.Case, "nomeCasa", "codiceFiscale");
            return View();
        }

        // POST: GestioneCasas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nomeCasa,longitude,latitude,noteComuni")] GestioneCasa gestioneCasa)
        {
            if (ModelState.IsValid)
            {
                db.GestioneCase.Add(gestioneCasa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nomeCasa = new SelectList(db.Case, "nomeCasa", "codiceFiscale", gestioneCasa.nomeCasa);
            return View(gestioneCasa);
        }

        // GET: GestioneCasas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestioneCasa gestioneCasa = await db.GestioneCase.FindAsync(id);
            if (gestioneCasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.nomeCasa = new SelectList(db.Case, "nomeCasa", "codiceFiscale", gestioneCasa.nomeCasa);
            return View(gestioneCasa);
        }

        // POST: GestioneCasas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nomeCasa,longitude,latitude,noteComuni")] GestioneCasa gestioneCasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestioneCasa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nomeCasa = new SelectList(db.Case, "nomeCasa", "codiceFiscale", gestioneCasa.nomeCasa);
            return View(gestioneCasa);
        }

        // GET: GestioneCasas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestioneCasa gestioneCasa = await db.GestioneCase.FindAsync(id);
            if (gestioneCasa == null)
            {
                return HttpNotFound();
            }
            return View(gestioneCasa);
        }

        // POST: GestioneCasas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            GestioneCasa gestioneCasa = await db.GestioneCase.FindAsync(id);
            db.GestioneCase.Remove(gestioneCasa);
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
