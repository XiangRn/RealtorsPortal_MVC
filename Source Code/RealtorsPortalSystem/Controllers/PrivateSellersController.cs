using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorsPortalSystem.Models;

namespace RealtorsPortalSystem.Controllers
{
    public class PrivateSellersController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: PrivateSellers
        public ActionResult Index()
        {
            string seller= Session["seller"].ToString();
            return View(db.PrivateSellers.Where(s=>s.SeLLAcount.Equals(seller)).ToList());
        }

        // GET: PrivateSellers/Details/5
        public ActionResult DetailsSeller(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // GET: PrivateSellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrivateSellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeLLId,SeLLAcount,SellPassword,SellFullname,SellGender,SellDob,SellAddress,SellPhone,SellEmail,isActive")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.PrivateSellers.Add(privateSeller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privateSeller);
        }

        // GET: PrivateSellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // POST: PrivateSellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeLLId,SeLLAcount,SellPassword,SellFullname,SellGender,SellDob,SellAddress,SellPhone,SellEmail,isActive")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privateSeller).State = EntityState.Modified;
                
                db.SaveChanges();
                Session["seller"] = privateSeller.SeLLAcount;

            }
            return RedirectToAction("Index", "PrivateSellers");
        }

        // GET: PrivateSellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // POST: PrivateSellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            db.PrivateSellers.Remove(privateSeller);
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
