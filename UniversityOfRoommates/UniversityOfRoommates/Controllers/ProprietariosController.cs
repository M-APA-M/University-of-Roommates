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
    public class ProprietariosController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proprietarios
        public async Task<ActionResult> Index()
        {
            var proprietario = db.Proprietari.Include(p => p.Utente);
            return View(await proprietario.ToListAsync());
        }

        // GET: Proprietarios/Details/5
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

        public async Task<ActionResult> DetailsMap(string id)
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

        // GET: Proprietarios/Create
        public ActionResult Create()
        {
            string name= System.Web.HttpContext.Current.User.Identity.Name;
            ViewBag.UserName = db.Users.Where(m => m.UserName == name).First().Id;
            //ViewBag.UserName = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Proprietarios/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,iban,paypalMe,cartaIdentità")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Proprietari.Add(proprietario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.Users, "Id", "nome", proprietario.UserId);
            return View(proprietario);
        }

        // GET: Proprietarios/Edit/5
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
            string name = System.Web.HttpContext.Current.User.Identity.Name;
            ViewBag.UserName = db.Users.Where(m => m.UserName == name).First().Id;
            return View(proprietario);
        }

        // POST: Proprietarios/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,iban,paypalMe,cartaIdentità")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.Users, "Id", "nome", proprietario.UserId);
            return View(proprietario);
        }

        // GET: Proprietarios/Delete/5
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

        // POST: Proprietarios/Delete/5
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
