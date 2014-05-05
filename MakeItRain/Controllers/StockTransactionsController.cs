using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeItRain.Models;

namespace MakeItRain.Controllers
{
    public class StockTransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockTransactions
        public ActionResult Index()
        {
            var stockTransactions = db.StockTransactions.Include(s => s.User);
            return View(stockTransactions.ToList());
        }

        // GET: StockTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransaction stockTransaction = db.StockTransactions.Find(id);
            if (stockTransaction == null)
            {
                return HttpNotFound();
            }
            return View(stockTransaction);
        }

        // GET: StockTransactions/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: StockTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Timestamp,StockID,StockName,StockAmount,StockPrice")] StockTransaction stockTransaction)
        {
            if (ModelState.IsValid)
            {
                db.StockTransactions.Add(stockTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.IdentityUsers, "Id", "UserName", stockTransaction.UserID);
            return View(stockTransaction);
        }

        // GET: StockTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransaction stockTransaction = db.StockTransactions.Find(id);
            if (stockTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.IdentityUsers, "Id", "UserName", stockTransaction.UserID);
            return View(stockTransaction);
        }

        // POST: StockTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Timestamp,StockID,StockName,StockAmount,StockPrice")] StockTransaction stockTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.IdentityUsers, "Id", "UserName", stockTransaction.UserID);
            return View(stockTransaction);
        }

        // GET: StockTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransaction stockTransaction = db.StockTransactions.Find(id);
            if (stockTransaction == null)
            {
                return HttpNotFound();
            }
            return View(stockTransaction);
        }

        // POST: StockTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockTransaction stockTransaction = db.StockTransactions.Find(id);
            db.StockTransactions.Remove(stockTransaction);
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
