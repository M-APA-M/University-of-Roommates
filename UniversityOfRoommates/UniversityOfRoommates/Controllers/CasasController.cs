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
            ViewBag.UserName = new SelectList(db.Proprietari, "UserName", "iban");
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nomeCasa,longitudine,latitudine,UserName,provincia,city,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Case.Add(casa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.Proprietari, "UserName", "iban", casa.UserName);
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
            ViewBag.UserName = new SelectList(db.Proprietari, "UserName", "iban", casa.UserName);
            return View(casa);
        }

        // POST: Casas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nomeCasa,longitudine,latitudine,UserName,provincia,city,indirizzo,civico,cap,numeroServizi,metraturaInterna,metraturaEsterna,postoAuto,descrizioneServizi")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.Proprietari, "UserName", "iban", casa.UserName);
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
        /*praticamente per poter tireare i dati dal db e metterli in una view 
        bisogna creare una cosa come sotto e dopo averla finita clccare col destro sul nome e 
        fare aggiungi visualizz che genera una view chiamata "getPOI" che include la lista di 
        Circondariato che sarà accessibile dall'html scrivendo @Model.quello_che_ti_serve

        Se invece si vuole usare una view esistente basta scrivere codice dentro una funzione come quella sotto già esistente e passare i parametri desiderati (anche nel return View())
        */
        public async Task<ActionResult> GetLocations()
        {
            int raggio = 0;
            List<Circondariato> circ = new List<Circondariato>();
            if (raggio == 0)
            {
                //carica tutto
                foreach (Casa c in await db.Case.ToListAsync())
                {
                    Circondariato ci = new Circondariato();
                    ci.nomeCasa = c.nomeCasa;
                    ci.lon = c.longitudine;
                    ci.lat = c.latitudine;
                    ci.indirizzo = c.indirizzo + "," + c.civico + " ," + c.city;
                    circ.Add(ci);
                }
            }
            else
            {
                //carica solo nel raggio  
                foreach (Casa c in await db.Case.Where(m => m.latitudine <= m.latitudine + (raggio / 200) &&
                                                     m.latitudine >= m.latitudine - (raggio / 200) &&
                                                     m.longitudine <= m.longitudine + (raggio / 200) &&
                                                     m.longitudine >= m.longitudine - (raggio / 200)).ToListAsync())
                {
                    Circondariato ci = new Circondariato();
                    ci.nomeCasa = c.nomeCasa;
                    ci.lon = c.longitudine;
                    ci.lat = c.latitudine;
                    ci.indirizzo = c.indirizzo + "," + c.civico + " ," + c.city;
                    circ.Add(ci);
                }
            }
            return View(circ.AsEnumerable());
        }

        //public ActionResult GetLocations()
        //{
        //    var casa = db.Case;

        //    return View(casa.AsEnumerable());
        //}
    }
}
