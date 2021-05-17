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
    public class Advertisements1Controller : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();


        // GET: Advertisements1
        public ActionResult Index(string cusname, int? page)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                string login = Session["login"].ToString();
                var advertisements = db.Advertisements.Include(a => a.Agent).Include(a => a.Category).Include(a => a.Mode).Include(a => a.PrivateSeller).Include(a => a.User)
                    .Where(a => a.AgentAcount.Equals(login) || a.SellAcount.Equals(login));
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
                    var result = newresult.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
                    return View(result);
                    
                }
            }
            
            
        }

        public ActionResult AddAdvertisementHistory()
        {
            string login = Session["login"].ToString();
            var addAdvDetails = db.UserAdvDetails.Where(a => a.AgentAccount.Equals(login) || a.SeLLAccount.Equals(login));
            return View(addAdvDetails.ToList());
        }

        // GET: Advertisements1/Details/5
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

        // GET: Advertisements1/Create
        public ActionResult Create()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                string login = Session["login"].ToString();
                ViewBag.AgentId = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentId", "AgentId");
                ViewBag.AgentAcount = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentAcount", "AgentAcount");
                ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
                ViewBag.ModeId = new SelectList(db.Modes, "ModeId", "ModeName");
                ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLId", "SeLLId");
                ViewBag.SeLLAcount = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLAcount", "SeLLAcount");
                //ViewBag.UserId = 1 /*new SelectList(db.Users, "UserId", "UserName")*/;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvId,UserId,SeLLId,ModeId,CateId,Header,Content,Price,Address,Street,District,Ward,CityProvince,Area,Photothumbnail,DateUp,ExpDate,AgentId,AgentAcount,SellAcount,Bedroom")] Advertisement advertisement
            , HttpPostedFileBase file,PhotoDetail photo, int? dropdownCity1, int? dropdownDistrict1, int? dropdownStreet1,
            int? dropdownWard1)
        {
            string login = Session["login"].ToString();
            ViewBag.AgentId = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentId", "AgentId", advertisement.AgentId);
            ViewBag.AgentAcount = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentAcount", "AgentAcount", advertisement.AgentAcount);
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", advertisement.CateId);
            ViewBag.ModeId = new SelectList(db.Modes, "ModeId", "ModeName", advertisement.ModeId);
            ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLId", "SeLLId", advertisement.SeLLId);
            ViewBag.SeLLAcount = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLAcount", "SeLLAcount", advertisement.SellAcount);
            //ViewBag.UserId =  new SelectList(db.Users, "UserId", "UserName", advertisement.UserId);
            try
            {
                

                if (file.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(file.FileName);

                    //advertisement.Photothumbnail = "/Lmages/" + fileName;
                    photo.AdvId = advertisement.AdvId;
                    
                    photo.Guidimage = Guid.NewGuid();
                    photo.Extension = Path.GetExtension(fileName);
                    photo.Image = "/Lmages/" + photo.Guidimage + photo.Extension;
                    advertisement.Photothumbnail = "/Lmages/" + photo.Guidimage + photo.Extension;
                    string pathFile = Path.Combine(Server.MapPath("~/Lmages/"), photo.Guidimage + photo.Extension);

                    file.SaveAs(pathFile);
                }
                if (Session["seller"] != null)
                {
                    advertisement.UserId = 1;
                }
                else
                {
                    advertisement.UserId = 2;
                }

                int cityId = int.Parse(dropdownCity1.ToString());

                var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                string namecity2 = new JavaScriptSerializer().Serialize(namecity);

                string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                advertisement.CityProvince = namecity3;


                int districtId = int.Parse(dropdownDistrict1.ToString());

                var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);
                advertisement.District = namedistrict3;

                int wardId = int.Parse(dropdownWard1.ToString());

                var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                advertisement.Ward = nameward3;

                int streetId = int.Parse(dropdownStreet1.ToString());

                var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                advertisement.Street = namestreet3;

                if (dropdownCity1 == null)
                {
                    ViewBag.Msg = "City field not empty!";
                }

                if (ModelState.IsValid)
                {
                    db.PhotoDetails.Add(photo);
            
                    db.Advertisements.Add(advertisement);

                    db.SaveChanges();


                    Session["photodetail"] = advertisement.AdvId;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ViewBag.Msg="Not except empty field";
            }
            

           
            return View(advertisement);
        }
        public ActionResult PayNow(int? id)
        {
           
            Advertisement advertisement = db.Advertisements.Find(id);
            
            return View(advertisement);
        }
        [HttpPost]
        public ActionResult PayNow(Advertisement advertisement, string expday, UserAdvDetail orderdetail)
        {
            var adv = db.Advertisements.SingleOrDefault(
                    p => p.AdvId.Equals(advertisement.AdvId));
            if (adv != null)
            {
               
                if (expday == "30days")
                {
                    adv.ExpDate = DateTime.Now.AddDays(30);
                    adv.DateUp = DateTime.Now;
                    adv.Paid = true;

                }
                else if (expday == "90days")
                {
                    adv.ExpDate = DateTime.Now.AddDays(90);
                    adv.DateUp = DateTime.Now;
                    adv.Paid = true;
                }
                else if (expday == "180days")
                {
                    adv.ExpDate = DateTime.Now.AddDays(180);
                    adv.DateUp = DateTime.Now;
                    adv.Paid = true;
                }
                

                db.SaveChanges();
            }
           

            if (expday == "30days")
            {
                orderdetail.AdvId = adv.AdvId;
                orderdetail.AdvTitle = adv.Header;
                orderdetail.UserId = adv.UserId;
                orderdetail.SeLLId = adv.SeLLId;
                orderdetail.SeLLAccount = adv.SellAcount;
                orderdetail.AgentId = adv.AgentId;
                orderdetail.AgentAccount = adv.AgentAcount;

                orderdetail.DateUp = adv.DateUp;
                orderdetail.ExpDate = adv.ExpDate;
                orderdetail.Onemonth = 1;
                orderdetail.Threemonths = 0;
                orderdetail.Sixmonths = 0;
                orderdetail.SubTotal = 2;
                db.UserAdvDetails.Add(orderdetail);
            }
            else if (expday == "90days")
            {
                orderdetail.AdvId = adv.AdvId;
                orderdetail.AdvTitle = adv.Header;
                orderdetail.UserId = adv.UserId;
                orderdetail.SeLLId = adv.SeLLId;
                orderdetail.SeLLAccount = adv.SellAcount;
                orderdetail.AgentId = adv.AgentId;
                orderdetail.AgentAccount = adv.AgentAcount;

                orderdetail.DateUp = adv.DateUp;
                orderdetail.ExpDate = adv.ExpDate;
                orderdetail.Onemonth = 0;
                orderdetail.Threemonths = 1;
                orderdetail.Sixmonths = 0;
                orderdetail.SubTotal = 5;
                db.UserAdvDetails.Add(orderdetail);
            }
            else if (expday == "180days")
            {
                orderdetail.AdvId = adv.AdvId;
                orderdetail.AdvTitle = adv.Header;
                orderdetail.UserId = adv.UserId;
                orderdetail.SeLLId = adv.SeLLId;
                orderdetail.SeLLAccount = adv.SellAcount;
                orderdetail.AgentId = adv.AgentId;
                orderdetail.AgentAccount = adv.AgentAcount;

                orderdetail.DateUp = adv.DateUp;
                orderdetail.ExpDate = adv.ExpDate;
                orderdetail.Onemonth = 0;
                orderdetail.Threemonths = 0;
                orderdetail.Sixmonths = 1;
                orderdetail.SubTotal = 8;
                db.UserAdvDetails.Add(orderdetail);
            }


           
            

            db.SaveChanges();
            return RedirectToAction("Index");
        }
            public ActionResult AdditionalPayment(int? id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);

            return View(advertisement);
        }
        [HttpPost]
        public ActionResult AdditionalPayment(Advertisement advertisement, string expday)
        {
            var adv = db.Advertisements.SingleOrDefault(
                    p => p.AdvId.Equals(advertisement.AdvId));
            if (adv != null)
            {

                if (expday == "30days")
                {
                    DateTime m = Convert.ToDateTime(adv.ExpDate);

                    adv.ExpDate = m.AddDays(30);
                    
                   

                }
                else if (expday == "90days")
                {
                    DateTime m = Convert.ToDateTime(adv.ExpDate);

                    adv.ExpDate = m.AddDays(90);

                }
                else if (expday == "180days")
                {
                    DateTime m = Convert.ToDateTime(adv.ExpDate);

                    adv.ExpDate = m.AddDays(180);

                }


                db.SaveChanges();
            }

         



                UserAdvDetail orderdetail = db.UserAdvDetails.SingleOrDefault(m => m.AdvId == advertisement.AdvId);

                orderdetail.ExpDate = adv.ExpDate;
                if (expday == "30days")
                {
                    orderdetail.Onemonth += 1;
                    orderdetail.SubTotal += 2;
                }
                else if (expday == "90days")
                {
                    orderdetail.Threemonths += 1;
                    orderdetail.SubTotal += 5;
                }
                else if (expday == "180days")
                {
                    orderdetail.Sixmonths += 1;
                    orderdetail.SubTotal += 8;
                }

              
                db.SaveChanges();



                return RedirectToAction("Index");
            
           
            
        }
        public ActionResult AddPaymentNewPakage(int? id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);

            return View(advertisement);
        }
        [HttpPost]
        public ActionResult AddPaymentNewPakage(Advertisement advertisement, string expday)
        {
            var adv = db.Advertisements.SingleOrDefault(
                    p => p.AdvId.Equals(advertisement.AdvId));
            if (adv != null)
            {

                if (expday == "30days")
                {
                    adv.DateUp = DateTime.Now;

                    adv.ExpDate = DateTime.Now.AddDays(30);
                    adv.Approved = true;
                    adv.Paid = true;



                }
                else if (expday == "90days")
                {
                    adv.DateUp = DateTime.Now;

                    adv.ExpDate = DateTime.Now.AddDays(90);
                    adv.Approved = true;
                    adv.Paid = true;

                }
                else if (expday == "180days")
                {
                    adv.DateUp = DateTime.Now;

                    adv.ExpDate = DateTime.Now.AddDays(180);
                    adv.Approved = true;
                    adv.Paid = true;

                }
                else if (expday == "0day")
                {
                    return RedirectToAction("Index");
                }
                    db.Advertisements.Add(adv);

                db.SaveChanges();
            }

            UserAdvDetail orderdetail = db.UserAdvDetails.SingleOrDefault(m => m.AdvId == advertisement.AdvId);


            if (expday == "30days")
            {
                orderdetail.DateUp = DateTime.Now;
                orderdetail.ExpDate = DateTime.Now.AddDays(30);
                orderdetail.Onemonth = 1;
                orderdetail.SubTotal = 2;
            }
            else if (expday == "90days")
            {
                orderdetail.DateUp = DateTime.Now;
                orderdetail.ExpDate = DateTime.Now.AddDays(90);
                orderdetail.Threemonths = 1;
                orderdetail.SubTotal = 5;
            }
            else if (expday == "180days")
            {
                orderdetail.DateUp = DateTime.Now;
                orderdetail.ExpDate = DateTime.Now.AddDays(180);
                orderdetail.Sixmonths = 1;
                orderdetail.SubTotal = 8;
            }
            else if (expday == "0day")
            {
                return RedirectToAction("Index");
            }

                db.UserAdvDetails.Add(orderdetail);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

            public ActionResult EditPhotoDetail(int? id)
        {
            //id = int.Parse(Session["photodetail"].ToString());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement support = db.Advertisements.SingleOrDefault(x => x.AdvId == id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhotoDetail(Advertisement support, PhotoDetail fileDetail)
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    fileDetail.AdvId = support.AdvId;

                    fileDetail.Guidimage = Guid.NewGuid();
                    fileDetail.Extension = Path.GetExtension(fileName);
                    fileDetail.Image = "/Lmages/" + fileDetail.Guidimage + fileDetail.Extension;


                    var path = Path.Combine(Server.MapPath("~/Lmages/"), fileDetail.Guidimage + fileDetail.Extension);
                    file.SaveAs(path);

                    db.PhotoDetails.Add(fileDetail);
                    db.SaveChanges();
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Advertisements1/Edit/5
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
            string login = Session["login"].ToString();
            ViewBag.AgentId = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentId", "AgentId");
            ViewBag.AgentAcount = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentAcount", "AgentAcount");
            ViewBag.CateId = new SelectList(db.Categories.Where(m => m.CateId==advertisement.CateId), "CateId", "CateName");
            ViewBag.ModeId = new SelectList(db.Modes.Where(m => m.ModeId==advertisement.ModeId), "ModeId", "ModeName");
            ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLId", "SeLLId");
            ViewBag.SeLLAcount = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLAcount", "SeLLAcount");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View(advertisement);
        }

        // POST: Advertisements1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisement advertisement, HttpPostedFileBase file,PhotoDetail photo, int? dropdownCity1, int? dropdownDistrict1, int? dropdownStreet1,
            int? dropdownWard1,int? mode,int? cate)
        {
            string login = Session["login"].ToString();
            ViewBag.AgentId = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentId", "AgentId", advertisement.AgentId);
            ViewBag.AgentAcount = new SelectList(db.Agents.Where(m => m.AgentAcount.Equals(login)), "AgentAcount", "AgentAcount", advertisement.AgentAcount);
            ViewBag.CateId = new SelectList(db.Categories.Where(m => m.CateId==advertisement.CateId), "CateId", "CateName", advertisement.CateId);
            ViewBag.ModeId = new SelectList(db.Modes.Where(m => m.ModeId==advertisement.ModeId), "ModeId", "ModeName", advertisement.ModeId);
            ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLId", "SeLLId", advertisement.SeLLId);
            ViewBag.SeLLAcount = new SelectList(db.PrivateSellers.Where(m => m.SeLLAcount.Equals(login)), "SeLLAcount", "SeLLAcount", advertisement.SellAcount);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", advertisement.UserId);





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

                    ViewBag.clist = db.Modes;

                    adv.Header = advertisement.Header;
                    adv.SeLLId = advertisement.SeLLId;
                    adv.SellAcount = advertisement.SellAcount;
                    adv.AgentId = advertisement.AgentId;
                    adv.AgentAcount = advertisement.AgentAcount;

                    if (mode == null)
                    {
                        adv.ModeId = adv.ModeId;
                    }else if (mode == 1)
                    {
                        adv.ModeId = 1;
                    }
                    else if (mode == 2)
                    {
                        adv.ModeId = 2;
                    }
                    else if (mode == 3)
                    {
                        adv.ModeId = 3;
                    }
                    else if (mode == 4)
                    {
                        adv.ModeId = 4;
                    }

                    if (cate == null)
                    {
                        adv.CateId = adv.CateId;
                    }
                    else if (cate == 1)
                    {
                        adv.CateId = 1;
                    }
                    else if (cate == 2)
                    {
                        adv.CateId = 2;
                    }
                    else if (cate == 3)
                    {
                        adv.CateId = 3;
                    }
                    else if (cate == 4)
                    {
                        adv.CateId = 4;
                    }
                    else if (cate == 5)
                    {
                        adv.CateId = 5;
                    }



                    adv.Content = advertisement.Content;
                    adv.Price = advertisement.Price;
                    adv.Address = advertisement.Address;
                    adv.Area = advertisement.Area;
                    adv.Bedroom = advertisement.Bedroom;
                    db.SaveChanges();
                    if (file.ContentLength > 0)
                    {

                        string fileName = Path.GetFileName(file.FileName);


                        photo.AdvId = advertisement.AdvId;

                        photo.Guidimage = Guid.NewGuid();
                        photo.Extension = Path.GetExtension(fileName);
                        photo.Image = "/Lmages/" + photo.Guidimage + photo.Extension;
                        adv.Photothumbnail = "/Lmages/" + photo.Guidimage + photo.Extension;
                        string pathFile = Path.Combine(Server.MapPath("~/Lmages/"), photo.Guidimage + photo.Extension);

                        file.SaveAs(pathFile);
                        db.PhotoDetails.Add(photo);

                    }
                    else
                    {
                        adv.Photothumbnail = advertisement.Photothumbnail;
                    }
                    db.SaveChanges();
                    //return RedirectToAction("Index", "Advertisements1");
                }
          
                
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }



            return RedirectToAction("Index", "Advertisements1");
        }


        //public ActionResult DeleteFile(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return RedirectToAction("Index");
        //    }
        //    try
        //    {
        //        Guid guid = new Guid(id);
        //        PhotoDetail fileDetail = db.PhotoDetails.SingleOrDefault(m=>m.Guidimage.Equals(guid));
        //        if (fileDetail == null)
        //        {
        //            Response.StatusCode = (int)HttpStatusCode.NotFound;
        //            return RedirectToAction("Index");
        //        }

        //        //Remove from database
        //        db.PhotoDetails.Remove(fileDetail);
        //        db.SaveChanges();

        //        //Delete file from the file system
        //        var path = Path.Combine(Server.MapPath("~/Lmages/"), fileDetail.Guidimage + fileDetail.Extension);
        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                PhotoDetail fileDetail = db.PhotoDetails.SingleOrDefault(m => m.Guidimage.Equals(guid));
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.PhotoDetails.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Lmages/"), fileDetail.Guidimage + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        // GET: Advertisements1/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Advertisement advertisement = db.Advertisements.Find(id);
        //    if (advertisement == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(advertisement);
        //}

        // POST: Advertisements1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
            Advertisement advertisement = db.Advertisements.Find(id);
            foreach (var item in advertisement.PhotoDetails)
            {
                String path = Path.Combine(Server.MapPath("~/Lmages/"), item.Guidimage + item.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

            }


            db.Advertisements.Remove(advertisement);
          
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
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
