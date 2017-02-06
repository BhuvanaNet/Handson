using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo1.Models;

namespace demo1.Controllers
{
    public class EmpController : Controller
    {
        private bhucdc2sqldb1Entities db = new bhucdc2sqldb1Entities();

        // GET: Emp
        public ActionResult Index()
        {
            return View(db.Emp_Table.ToList());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Table emp_Table = db.Emp_Table.Find(id);
            if (emp_Table == null)
            {
                return HttpNotFound();
            }
            return View(emp_Table);
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,Name,Address,Age,Salary")] Emp_Table emp_Table)
        {
            if (ModelState.IsValid)
            {
                db.Emp_Table.Add(emp_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp_Table);
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Table emp_Table = db.Emp_Table.Find(id);
            if (emp_Table == null)
            {
                return HttpNotFound();
            }
            return View(emp_Table);
        }

        // POST: Emp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,Name,Address,Age,Salary")] Emp_Table emp_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp_Table);
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Table emp_Table = db.Emp_Table.Find(id);
            if (emp_Table == null)
            {
                return HttpNotFound();
            }
            return View(emp_Table);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp_Table emp_Table = db.Emp_Table.Find(id);
            db.Emp_Table.Remove(emp_Table);
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
