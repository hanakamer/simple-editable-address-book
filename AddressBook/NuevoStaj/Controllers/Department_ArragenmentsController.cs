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
    public class Department_ArragenmentsController : Controller
    {
        private NuevoEntities db = new NuevoEntities();

        // GET: Department_Arragenments
        public ActionResult Index()
        {
            var department_Arragenments = db.Department_Arragenments.Include(d => d.Departments).Include(d => d.Managers);
            return View(department_Arragenments.ToList());
        }

        // GET: Department_Arragenments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Arragenments department_Arragenments = db.Department_Arragenments.Find(id);
            if (department_Arragenments == null)
            {
                return HttpNotFound();
            }
            return View(department_Arragenments);
        }

        // GET: Department_Arragenments/Create
        public ActionResult Create()
        {
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Name");
            ViewBag.Manager_ID = new SelectList(db.Managers, "Manager_ID", "Manager_ID");
            return View();
        }

        // POST: Department_Arragenments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Arrangement_ID,Department_ID,Manager_ID")] Department_Arragenments department_Arragenments)
        {
            if (ModelState.IsValid)
            {
                db.Department_Arragenments.Add(department_Arragenments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Name", department_Arragenments.Department_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "Manager_ID", "Manager_ID", department_Arragenments.Manager_ID);
            return View(department_Arragenments);
        }

        // GET: Department_Arragenments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Arragenments department_Arragenments = db.Department_Arragenments.Find(id);
            if (department_Arragenments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Name", department_Arragenments.Department_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "Manager_ID", "Manager_ID", department_Arragenments.Manager_ID);
            return View(department_Arragenments);
        }

        // POST: Department_Arragenments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Arrangement_ID,Department_ID,Manager_ID")] Department_Arragenments department_Arragenments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department_Arragenments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Name", department_Arragenments.Department_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "Manager_ID", "Manager_ID", department_Arragenments.Manager_ID);
            return View(department_Arragenments);
        }

        // GET: Department_Arragenments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Arragenments department_Arragenments = db.Department_Arragenments.Find(id);
            if (department_Arragenments == null)
            {
                return HttpNotFound();
            }
            return View(department_Arragenments);
        }

        // POST: Department_Arragenments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_Arragenments department_Arragenments = db.Department_Arragenments.Find(id);
            db.Department_Arragenments.Remove(department_Arragenments);
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
