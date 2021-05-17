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

using System.IO;
using System.Web.Script.Serialization;
namespace RealtorsPortalSystem.Controllers
{
    public class Advertisements2Controller : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Advertisements2
        public ActionResult Index(int? page, string cusname)
        {
            
                var advertisements = db.Advertisements.Include(a => a.Agent).Include(a => a.Category).Include(a => a.Mode).Include(a => a.PrivateSeller).Include(a => a.User);
                if (page == null)
                {
                    page = 1;
                }
                if (string.IsNullOrEmpty(cusname))
                {
                    var result = advertisements.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
                    return View(result);
                }
                else
                {
                    
                    var newresult = advertisements.Where(c => c.Header.ToLower().Contains(cusname.ToLower())
                                                       || c.Content.ToLower().Contains(cusname.ToLower())
                                                       || c.District.ToLower().Contains(cusname.ToLower())
                                                       || c.CityProvince.ToLower().Contains(cusname.ToLower())
                                                       || c.Ward.ToLower().Contains(cusname.ToLower())
                                                       || c.Street.ToLower().Contains(cusname.ToLower())
                                                       || c.AdvId.ToString().Equals(cusname)
                                                       );
                    var result2 = newresult.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
                    return View(result2);
                }
               
             

            
        }

        // GET: Advertisements2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Advertisements2/Create
        public ActionResult Create()
        {
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentAcount");
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            ViewBag.ModeId = new SelectList(db.Modes, "ModeId", "ModeName");
            ViewBag.SeLLId = new SelectList(db.PrivateSellers, "SeLLId", "SeLLAcount");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Advertisements2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvId,UserId,SeLLId,ModeId,CateId,Header,Content,Price,Address,Street,District,Ward,CityProvince,Area,Photothumbnail,DateUp,ExpDate,AgentId,AgentAcount,SellAcount,Approved,Paid,Bedroom")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentAcount", advertisement.AgentId);
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", advertisement.CateId);
            ViewBag.ModeId = new SelectList(db.Modes, "ModeId", "ModeName", advertisement.ModeId);
            ViewBag.SeLLId = new SelectList(db.PrivateSellers, "SeLLId", "SeLLAcount", advertisement.SeLLId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", advertisement.UserId);
            return View(advertisement);
        }

        // GET: Advertisements2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentAcount", advertisement.AgentId);
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", advertisement.CateId);
            ViewBag.ModeId = new SelectList(db.Modes, "ModeId", "ModeName", advertisement.ModeId);
            ViewBag.SeLLId = new SelectList(db.PrivateSellers, "SeLLId", "SeLLAcount", advertisement.SeLLId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", advertisement.UserId);
            return View(advertisement);
        }

        // POST: Advertisements2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisement advertisement, int? dropdownCity1, int? dropdownDistrict1, int? dropdownStreet1,
            int? dropdownWard1)
        {

            try
            {
                var adv = db.Advertisements.SingleOrDefault(
                  p => p.AdvId.Equals(advertisement.AdvId));



                if (adv != null)
                {


                    if (dropdownCity1 == null)
                    {
                        adv.CityProvince = adv.CityProvince;
                    }
                    else if (dropdownDistrict1 == null)
                    {
                        adv.District = advertisement.District;
                    }
                    else if (dropdownWard1 == null)
                    {
                        adv.Ward = advertisement.Ward;
                    }
                    else if (dropdownStreet1 == null)
                    {
                        adv.Street = advertisement.Street;
                    }

                    else
                    {
                        int cityId = int.Parse(dropdownCity1.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);

                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        adv.CityProvince = namecity3;


                        int districtId = int.Parse(dropdownDistrict1.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);
                        adv.District = namedistrict3;

                        int wardId = int.Parse(dropdownWard1.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        adv.Ward = nameward3;

                        int streetId = int.Parse(dropdownStreet1.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        adv.Street = namestreet3;
                    }



                    adv.Header = advertisement.Header;
                  
                    adv.ModeId = advertisement.ModeId;
                    adv.Content = advertisement.Content;
                    adv.Price = advertisement.Price;
                    adv.Address = advertisement.Address;
                    adv.Area = advertisement.Area;
                    adv.Bedroom = advertisement.Bedroom;

                    adv.Approved = advertisement.Approved;
                  
                    db.SaveChanges();
                    //return RedirectToAction("Index", "Advertisements1");
                }


            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }



            return RedirectToAction("Index", "Advertisements2");
        }

        // GET: Advertisements2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisement);
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
