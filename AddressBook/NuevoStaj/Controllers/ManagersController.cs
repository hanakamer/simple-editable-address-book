using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NuevoStaj.Models;

namespace NuevoStaj.Controllers
{
    public class ManagersController : Controller
    {
        private NuevoEntities db = new NuevoEntities();

        // GET: Managers
        public ActionResult Index()
        {
            var managers = db.Managers.Include(m => m.Employees);
            return View(managers.ToList());
        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managers managers = db.Managers.Find(id);
            if (managers == null)
            {
                return HttpNotFound();
            }
            return View(managers);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Name");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manager_ID,Employee_ID")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(managers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Name", managers.Employee_ID);
            return View(managers);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managers managers = db.Managers.Find(id);
            if (managers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Name", managers.Employee_ID);
            return View(managers);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manager_ID,Employee_ID")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Name", managers.Employee_ID);
            return View(managers);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managers managers = db.Managers.Find(id);
            if (managers == null)
            {
                return HttpNotFound();
            }
            return View(managers);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Managers managers = db.Managers.Find(id);
            db.Managers.Remove(managers);
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
