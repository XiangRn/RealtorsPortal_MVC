using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorsPortalSystem.Models;

using System.IO;
using System.Web.Script.Serialization;
using PagedList;
namespace RealtorsPortalSystem.Controllers
{
    public class WardsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Wards
        public ActionResult Index(int? page, string cusname)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                var wards = db.Wards.Include(w => w.City).Include(w => w.District);
                if (page == null)
                {
                    page = 1;
                }
                if (string.IsNullOrEmpty(cusname))
                {
                    var result = wards.OrderByDescending(f => f.WardId).ToPagedList(page ?? 1, 10);
                    return View(result);
                }
                else
                {
                    
                    var newresult = wards.Where(c => c.City.CityName.ToLower().Contains(cusname.ToLower()) || c.District.DistrictName.ToLower().Contains(cusname.ToLower()) || c.WardName.ToLower().Contains(cusname.ToLower())
                                                       );
                    var result2 = newresult.OrderByDescending(f => f.WardId).ToPagedList(page ?? 1, 10);
                    return View(result2);
                }

            }

        }

        // GET: Wards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // GET: Wards/Create
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
                return View();
            }
        }

        // POST: Wards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WardId,CityId,DistrictId,WardName")] Ward ward, int? dropdownCity1, int? dropdownDistrict1)
        {
            

            ward.CityId = dropdownCity1;


            ward.DistrictId = dropdownDistrict1;
            var city2 = db.Wards.SingleOrDefault(u => u.WardName.Equals(ward.WardName) && u.CityId==dropdownCity1 && u.DistrictId==dropdownDistrict1);
            if (ModelState.IsValid)
            {
                if (city2 == null)
                {
                    db.Wards.Add(ward);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Msg = "Ward Name has exits";
                }
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", ward.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", ward.DistrictId);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", ward.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", ward.DistrictId);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WardId,CityId,DistrictId,WardName")] Ward ward, int? dropdownCity1, int? dropdownDistrict1)
        {

            var adv = db.Wards.SingleOrDefault(
                  p => p.WardId.Equals(ward.WardId));
            if (dropdownCity1 == null)
            {
                adv.CityId = adv.CityId;
                
            }else if (dropdownDistrict1==null)
            {
                adv.DistrictId = ward.DistrictId;
            }
            
            else
            {
                adv.CityId = dropdownCity1;


                adv.DistrictId = dropdownDistrict1;

                

            }
            adv.WardName = ward.WardName;

            db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }

        // GET: Wards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ward ward = db.Wards.Find(id);
            db.Wards.Remove(ward);
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
