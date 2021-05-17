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
    public class StreetsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Streets
        public ActionResult Index(int? page, string cusname)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                var streets = db.Streets.Include(s => s.City).Include(s => s.District).Include(s => s.Ward);
                if (page == null)
                {
                    page = 1;
                }
                if (string.IsNullOrEmpty(cusname))
                {
                    var result = streets.OrderByDescending(f => f.StreetId).ToPagedList(page ?? 1, 10);
                    return View(result);
                }
                else
                {
                    
                    var newresult = streets.Where(c => c.City.CityName.ToLower().Contains(cusname.ToLower()) || c.District.DistrictName.ToLower().Contains(cusname.ToLower()) || c.Ward.WardName.ToLower().Contains(cusname.ToLower()) || c.StreetName.ToLower().Contains(cusname.ToLower())
                                                       );
                    var result2 = newresult.OrderByDescending(f => f.StreetId).ToPagedList(page ?? 1, 10);
                    return View(result2);
                }
            }
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
                ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
                ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName");
                return View();
            }
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StreetId,CityId,DistrictId,WardId,StreetName")] Street street, int? dropdownCity1, int? dropdownDistrict1,int? dropdownWard1)
        {
            street.CityId = dropdownCity1;
            street.DistrictId= dropdownDistrict1;
            street.WardId = dropdownWard1;
            var city2 = db.Streets.SingleOrDefault(u => u.StreetName.Equals(street.StreetName) && u.CityId == dropdownCity1 
            && u.DistrictId == dropdownDistrict1 && u.WardId==dropdownWard1);
            if (ModelState.IsValid)
            {
                if (city2 == null)
                {
                    db.Streets.Add(street);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                {
                    ViewBag.Msg = "Street Name has exits";
                }
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", street.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", street.DistrictId);
            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName", street.WardId);
            return View(street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", street.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", street.DistrictId);
            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName", street.WardId);
            return View(street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StreetId,CityId,DistrictId,WardId,StreetName")] Street street, int? dropdownCity1, int? dropdownDistrict1, int? dropdownWard1)
        {
            var adv = db.Streets.SingleOrDefault(
                 p => p.StreetId.Equals(street.StreetId));
            if (dropdownCity1 == null)
            {
                adv.CityId = adv.CityId;

            }
            else if (dropdownDistrict1 == null)
            {
                adv.DistrictId = street.DistrictId;
            }
            else if (dropdownWard1 == null)
            {
                adv.WardId = street.WardId;
            }

            else
            {
                adv.CityId = dropdownCity1;


                adv.DistrictId = dropdownDistrict1;

                adv.WardId = dropdownWard1;

            }
            adv.StreetName = street.StreetName;

            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
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
