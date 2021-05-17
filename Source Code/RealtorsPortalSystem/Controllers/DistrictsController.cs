using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorsPortalSystem.Models;
using PagedList;
namespace RealtorsPortalSystem.Controllers
{
    public class DistrictsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Districts
        public ActionResult Index(int? page, string cusname)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                var districts = db.Districts.Include(d => d.City);
                if (page == null)
                {
                    page = 1;
                }
                if (string.IsNullOrEmpty(cusname))
                {
                    var result = districts.OrderByDescending(f => f.DistrictId).ToPagedList(page ?? 1, 10);
                    return View(result);
                }
                else
                {

                    var newresult = districts.Where(c => c.City.CityName.ToLower().Contains(cusname.ToLower()) || c.DistrictName.ToLower().Contains(cusname.ToLower())
                                                       );
                    var result2 = newresult.OrderByDescending(f => f.DistrictId).ToPagedList(page ?? 1, 10);
                    return View(result2);
                }

            }

               
        }

        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
                return View();
            }
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictId,CityId,DistrictName")] District district)
        {
            var city2 = db.Districts.SingleOrDefault(u => u.DistrictName.Equals(district.DistrictName) && u.CityId==district.CityId);
            if (ModelState.IsValid)
            {
                if (city2 == null)
                {
                    db.Districts.Add(district);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else{
                    ViewBag.Msg = "District Name has exits";
                }
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", district.CityId);
            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", district.CityId);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictId,CityId,DistrictName")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", district.CityId);
            return View(district);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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
