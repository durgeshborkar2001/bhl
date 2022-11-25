using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models; 

namespace MvcApplication3.Controllers
{
    public class ProductController : Controller
    {
        private DurgeshEntities1 db = new DurgeshEntities1();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(db.tblproductdetails.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            tblproductdetail tblproductdetail = db.tblproductdetails.Find(id);
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(tblproductdetail tblproductdetail)
        {
            if (ModelState.IsValid)
            {
                db.tblproductdetails.Add(tblproductdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblproductdetail);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblproductdetail tblproductdetail = db.tblproductdetails.Find(id);
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(tblproductdetail tblproductdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblproductdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblproductdetail);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblproductdetail tblproductdetail = db.tblproductdetails.Find(id);
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        // 
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tblproductdetail tblproductdetail = db.tblproductdetails.Find(id);
            db.tblproductdetails.Remove(tblproductdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}