using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealtorsPortalSystem.Models;

using System.Data.Entity;
using System.Net;
namespace RealtorsPortalSystem.Controllers
{
    public class AdminsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Admin

        public ActionResult Index()
        {
            if (Session["aname"] != null)
            {
                return View(db.Admins);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult Report(string search, DateTime? dFrom, DateTime? dTo)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var details = db.UserAdvDetails;
                if (search == "Search DateUP")
                {
                    var model = details.ToList().Where(p => (p.DateUp >= dFrom) && (p.DateUp <= dTo));

                    return View(model);
                }
                else if (search == "Search ExpDate")
                {
                    var model = details.ToList().Where(p => (p.ExpDate >= dFrom) && (p.ExpDate <= dTo));

                    return View(model);
                }

                return View(db.UserAdvDetails.ToList());
            }
               
        }

        public ActionResult CityList()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(db.Cities.ToList());
            }
                
        }

        public ActionResult DetailsCity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        public ActionResult CreateCity()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
                
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCity([Bind(Include = "CityId,CityName")] City city)
        {
            var city2= db.Cities.SingleOrDefault(u => u.CityName.Equals(city.CityName));
            if (ModelState.IsValid)
            {
                if (city2 == null)
                {
                    db.Cities.Add(city);
                    db.SaveChanges();
                    return RedirectToAction("CityList", "Admins");
                }
                else
                {
                    ViewBag.Msg = "City Name has exits";
                }
            }

            return View(city);
        }

        public ActionResult EditCity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCity([Bind(Include = "CityId,CityName")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CityList", "Admins");
            }
            return View(city);
        }

        public ActionResult DeleteCity(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("CityList", "Admins");
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Admins/Login
        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            try
            {
                var admin = db.Admins.SingleOrDefault(a => a.AdminAcount.Equals(uname));

                if (admin != null)
                {


                    if (admin.AdminPass.Equals(pwd))
                    {
                        Session["aname"] = admin.AdminAcount;


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "Invalid Password!!!";
                    }

                }
                else
                {
                    ViewBag.Msg = "This account didn't existed!!!";
                }
            }

            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["aname"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admins");
        }

        public ActionResult DisplayMyAccount()
        {
            if (Session["aname"] != null)
            {
                string m = Session["aname"].ToString();
                var result = db.Admins.Where(p => p.AdminAcount.Equals(m));
                return View(result);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult EditPassword(string id)
        {

            var res = db.Admins.Find(id);
            return View(res);
        }
        [HttpPost]
        public ActionResult EditPassword(Admin admin)
        {
            try
            {
                var res = db.Admins.SingleOrDefault(a => a.AdminAcount.Equals(admin.AdminAcount));
                if (ModelState.IsValid)
                {
                    if (admin != null)
                    {

                        res.AdminPass = admin.AdminPass;
                        db.SaveChanges();
                        return RedirectToAction("Index","Admins");
                    }
                   
                }

            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();


        }

        public ActionResult AdminDisplayFeedback()
        {
            return View(db.Feedbacks);
        }
        public ActionResult ReplyFeedBack(int? id)
        {
            var result = db.Feedbacks.Find(id);

            return View(result);
        }
        [HttpPost]
        public ActionResult ReplyFeedBack(Feedback replyFeedback)
        {
            try
            {
                var feedback = db.Feedbacks.SingleOrDefault(f => f.FeedbackId.Equals(replyFeedback.FeedbackId));
                if (feedback != null)
                {
                    feedback.FeedbackReply = replyFeedback.FeedbackReply;


                    db.SaveChanges();
                    return RedirectToAction("AdminDisplayFeedback");
                }
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();

        }

        public ActionResult DisplayRepliedFeedback(int? id)
        {
            var result = db.Feedbacks.Find(id);

            return View(result);
        }

        public ActionResult PhotoDetails(int? id)
        {
            var result = db.PhotoDetails.Where(p => p.AdvId == id);
            if (id == null)
            {
                return View(db.PhotoDetails);
            }
            else
            {
                return View(result);
            }

        }
        public ActionResult PhotoDetailsDelete(int? id)
        {
            var result = db.PhotoDetails.Find(id);
            db.PhotoDetails.Remove(result);
            db.SaveChanges();
            return RedirectToAction("PhotoDetails");
        }
        public ActionResult Selleracount()
        {
            return View(db.PrivateSellers);
        }

        public ActionResult SellerActice(int? id)
        {
            var result = db.PrivateSellers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult SellerActice(PrivateSeller editActive)
        {
            try
            {
                var active = db.PrivateSellers.SingleOrDefault(f => f.SeLLId.Equals(editActive.SeLLId));
                if (active != null)
                {
                    active.SellActive = editActive.SellActive;


                    db.SaveChanges();
                    return RedirectToAction("Selleracount");
                }
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();
        }

        public ActionResult Agentacount()
        {
            return View(db.Agents);
        }

        public ActionResult AgentActice(int? id)
        {
            var result = db.Agents.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult AgentActice(Agent editActive)
        {
            try
            {
                var active = db.Agents.SingleOrDefault(f => f.AgentId.Equals(editActive.AgentId));
                if (active != null)
                {
                    active.AgentActive = editActive.AgentActive;


                    db.SaveChanges();
                    return RedirectToAction("Agentacount");
                }
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();
        }
        public ActionResult AddLastedNew()
        {
            ViewBag.cList = new SelectList(db.Advertisements, "AdvId", "Header");
            return View();
        }
        [HttpPost]
        public ActionResult AddLastedNew(LastedNew addNews)
        {
            try
            {
                ViewBag.cList = new SelectList(db.Advertisements, "AdvId", "Header");

                if (ModelState.IsValid)
                {

                    db.LastedNews.Add(addNews);
                    db.SaveChanges();

                    return RedirectToAction("Index");


                }
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
            }
            return View();
        }
    }
}