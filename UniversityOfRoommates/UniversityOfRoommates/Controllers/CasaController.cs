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
    public class CasaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Casa
        public async Task<ActionResult> Index()
        {
            var casa = db.Case.Include(c => c.Proprietario);
            return View(await casa.ToListAsync());
        }

        // GET: Casa/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: Casa/Create
        public ActionResult Create()
        {
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "codiceFiscale", "iban");
            return View();
        }

        // POST: Casa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCasa,codiceFiscale,longitudine,latitudine,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Case.Add(casa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "codiceFiscale", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // GET: Casa/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "codiceFiscale", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // POST: Casa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCasa,codiceFiscale,longitudine,latitudine,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codiceFiscale = new SelectList(db.Proprietari, "codiceFiscale", "iban", casa.codiceFiscale);
            return View(casa);
        }

        // GET: Casa/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Casa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
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

        public List<Casa> getPOI(decimal lo, decimal la,int raggio)
        {
            List<Casa> circ = new List<Casa>();
            if (raggio == 0)
            {
                //carica tutto
                foreach(Casa c in db.Case) { circ.Add(c); }
            }
            else
            {
                //carica solo nel raggio 
            }
            return circ;
        }

        public ActionResult GetLocations()
        {
            var casa = db.Case;
            
            return View(casa.AsEnumerable());
        }
    }
}
