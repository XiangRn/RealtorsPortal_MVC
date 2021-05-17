using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using RealtorsPortalSystem.Models;
using PagedList;
namespace RealtorsPortalSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        RealtorsPortal db = new RealtorsPortal();
        public ActionResult Index(string search, int? dropdownCity, int? dropdownDistrict, int? dropdownStreet,
            int? dropdownWard,int? mode1,double? areafrom1,double? areato1,double? pricefrom1, double? priceto1,int? bedroom1)
        {
            Session["search"] = search;
            Session["city"] = dropdownCity;
            Session["district"] = dropdownDistrict;
            Session["street"] = dropdownStreet;
            Session["ward"] = dropdownWard;
            Session["mode"] = mode1;
            Session["areafrom"] = areafrom1;
            Session["areato"] = areato1;
            Session["pricefrom"] = pricefrom1;
            Session["priceto"] = priceto1;
            Session["bedroom"] = bedroom1;
          

            if ((string.IsNullOrEmpty(search) && (dropdownCity == null || dropdownCity == 0) && (dropdownDistrict == null || dropdownDistrict == 0)
                 && (dropdownStreet == null || dropdownStreet == 0) && (dropdownWard == null || dropdownWard == 0))
                 && mode1==null && areafrom1==null && areato1==null && pricefrom1==null && priceto1==null && bedroom1==null)
            {

                return View(db.LastedNews);
            }

            else if (!string.IsNullOrEmpty(search))
            {
                return RedirectToAction("Search", "Home");
            }
            else
            {
                return RedirectToAction("Search", "Home");
            }

        }

        public ActionResult Search(int? page, string search, int? dropdownCity, int? dropdownDistrict, int? dropdownStreet,
            int? dropdownWard, int? mode1, double? areafrom1, double? areato1, double? pricefrom1, double? priceto1, int? bedroom1)
        {
            
            if (page == null)
            {
                page = 1;
            }

           
            var newresult = (from r in db.Advertisements select r);
             
            if ((Session["search"] != null || Session["mode"] != null ||
                Session["city"] != null || Session["district"] != null || Session["ward"] != null || Session["street"] != null || Session["mode"]!=null
                || Session["areafrom"]!= null || Session["areato"] != null || Session["pricefrom"] !=null || Session["priceto"]!= null 
                || Session["bedroom"] !=null))
            {
                if (Session["search"] != null)
                {
                    string search3 = Session["search"].ToString();


                    newresult = newresult.Where(c => c.Header.ToLower().Contains(search3.ToLower())
                                                   || c.Content.ToLower().Contains(search3.ToLower())
                                                   || c.District.ToLower().Contains(search3.ToLower())
                                                   || c.CityProvince.ToLower().Contains(search3.ToLower())
                                                   || c.Ward.ToLower().Contains(search3.ToLower())
                                                   || c.Street.ToLower().Contains(search3.ToLower())
                                                   );


                }


                if (Session["mode"] != null)
                {
                    int mode = int.Parse(Session["mode"].ToString());
                    newresult = newresult.Where(c => c.ModeId == mode);

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.ModeId == mode)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Area >= areafrom)
                                                    );
                    }

                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Area <= areato)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Price >= pricefrom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }

                }

                if (Session["areafrom"] != null)
                {
                    double areafrom = double.Parse(Session["areafrom"].ToString());

                    newresult = newresult.Where(c => c.Area >= areafrom
                                                );

                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area >= areafrom)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Area <= areato)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Price >= pricefrom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                }

                if (Session["areato"] != null)
                {
                    double areato = double.Parse(Session["areato"].ToString());

                    newresult = newresult.Where(c => c.Area <= areato
                                                );

                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area <= areato)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Area <= areato)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Price >= pricefrom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                }

                if (Session["priceto"] != null)
                {
                    double priceto = double.Parse(Session["priceto"].ToString());

                    newresult = newresult.Where(c => c.Price <= priceto
                                                );

                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price <= priceto)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Price >= pricefrom)
                                                    );
                    }



                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                }

                if (Session["pricefrom"] != null)
                {
                    double pricefrom = double.Parse(Session["pricefrom"].ToString());

                    newresult = newresult.Where(c => c.Price >= pricefrom
                                                );

                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.Price >= pricefrom
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price >= pricefrom)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Price >= pricefrom
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Price >= pricefrom
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Price >= pricefrom
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Price >= pricefrom)
                                                    );
                    }
                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Price >= pricefrom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Price >= pricefrom)
                                                    );
                    }


                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Price >= pricefrom
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                }

                if (Session["bedroom"] != null)
                {
                    double bedroom = double.Parse(Session["bedroom"].ToString());

                    newresult = newresult.Where(c => c.Bedroom >= bedroom
                                                );

                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.Bedroom >= bedroom
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["city"] != null)
                    {
                        int cityId = int.Parse(Session["city"].ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Bedroom >= bedroom
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Bedroom >= bedroom
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Bedroom >= bedroom
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }
                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Bedroom >= bedroom
                                                    && c.Price >= pricefrom)
                                                    );
                    }


                }

                if (Session["city"] != null)
                {
                    int cityId = int.Parse(Session["city"].ToString());

                    var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                    string namecity2 = new JavaScriptSerializer().Serialize(namecity);

                    Session["namecity2"] = namecity2;

                    string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                    newresult = newresult.Where(c => c.CityProvince.ToLower().Contains(namecity3.ToLower()));
                    if (Session["district"] != null)
                    {
                        int districtId = int.Parse(Session["district"].ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }
                    if (Session["ward"] != null)
                    {
                        int wardId = int.Parse(Session["ward"].ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }
                    if (Session["street"] != null)
                    {
                        int streetId = int.Parse(Session["street"].ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }
                    if (Session["mode"] != null)
                    {
                        int mode = int.Parse(Session["mode"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.ModeId == mode)
                                                    );
                    }

                    if (Session["areafrom"] != null)
                    {
                        double areafrom = double.Parse(Session["areafrom"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area >= areafrom)
                                                    );
                    }

                    if (Session["areato"] != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area <= areato)
                                                    );
                    }

                    if (Session["pricefrom"] != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price >= pricefrom)
                                                    );
                    }

                    if (Session["priceto"] != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price <= priceto)
                                                    );
                    }

                    if (Session["bedroom"] != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Bedroom >= bedroom)
                                                    );
                    }

                }

                Session.Remove("search");
                Session.Remove("mode");
                Session.Remove("city");
                Session.Remove("district");
                Session.Remove("street");
                Session.Remove("ward");
                Session.Remove("areafrom");
                Session.Remove("areato");
                Session.Remove("pricefrom");
                Session.Remove("priceto");
                Session.Remove("bedroom");

                var result = newresult.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 50);
                 return View(result);
                




            }else if ((mode1 == null && search == null && dropdownCity == null & areato1 == null && areafrom1 == null
                && pricefrom1 == null && priceto1 == null && bedroom1 == null))
            {
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                if (search != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");


                    newresult = newresult.Where(c => c.Header.ToLower().Contains(search.ToLower())
                                                   || c.Content.ToLower().Contains(search.ToLower())
                                                   || c.District.ToLower().Contains(search.ToLower())
                                                   || c.CityProvince.ToLower().Contains(search.ToLower())
                                                   || c.Ward.ToLower().Contains(search.ToLower())
                                                   || c.Street.ToLower().Contains(search.ToLower())
                                                   );


                }
                if (mode1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.ModeId == mode1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.ModeId == mode1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                    if (areafrom1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Area >= areafrom1)
                                                    );
                    }

                    if (areato1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Area <= areato1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.ModeId == mode1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }

                if (areafrom1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.Area >= areafrom1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area >= areafrom1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }

                  

                    if (areato1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Area <= areato1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (mode1 != null)
                    {
                        
                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.ModeId==mode1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }
                if (areato1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.Area <= areato1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area <= areato1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }



                    if (areafrom1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Area <= areato1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (mode1 != null)
                    {

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.ModeId == mode1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }

                if (priceto1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.Price <= priceto1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price <= priceto1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }



                    if (areafrom1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (areato1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (mode1 != null)
                    {

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.ModeId == mode1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }

                if (pricefrom1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.Price >= pricefrom1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price >= pricefrom1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }



                    if (areafrom1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (areato1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (mode1 != null)
                    {

                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.ModeId == mode1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }

                if (bedroom1 != null)
                {
                    Session.Remove("search");
                    Session.Remove("mode");
                    Session.Remove("city");
                    Session.Remove("district");
                    Session.Remove("street");
                    Session.Remove("ward");
                    Session.Remove("areafrom");
                    Session.Remove("areato");
                    Session.Remove("pricefrom");
                    Session.Remove("priceto");
                    Session.Remove("bedroom");
                    newresult = newresult.Where(c => c.Bedroom >= bedroom1);

                    if (dropdownCity != null)
                    {
                        int cityId = int.Parse(dropdownCity.ToString());

                        var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                        string namecity2 = new JavaScriptSerializer().Serialize(namecity);


                        string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.Bedroom >= bedroom1
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }

                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.Bedroom >= bedroom1
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }

                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.Bedroom >= bedroom1
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }



                    if (areafrom1 != null)
                    {
                        double areato = double.Parse(Session["areato"].ToString());

                        newresult = newresult.Where(c => (c.Area >= areafrom1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        double pricefrom = double.Parse(Session["pricefrom"].ToString());

                        newresult = newresult.Where(c => (c.Price <= priceto1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                    if (areato1 != null)
                    {
                        double priceto = double.Parse(Session["priceto"].ToString());

                        newresult = newresult.Where(c => (c.Area <= areato1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                    if (mode1 != null)
                    {

                        newresult = newresult.Where(c => (c.Bedroom >= bedroom1
                                                    && c.ModeId == mode1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        double bedroom = double.Parse(Session["bedroom"].ToString());

                        newresult = newresult.Where(c => (c.Price >= pricefrom1
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }

                if (dropdownCity != null)
                {
                    int cityId = int.Parse(dropdownCity.ToString());

                    var namecity = from a in db.Cities where a.CityId == cityId select a.CityName;
                    string namecity2 = new JavaScriptSerializer().Serialize(namecity);

                    

                    string namecity3 = namecity2.Substring(2, namecity2.Length - 4);

                    newresult = newresult.Where(c => c.CityProvince.ToLower().Contains(namecity3.ToLower()));
                    if (dropdownDistrict != null)
                    {
                        int districtId = int.Parse(dropdownDistrict.ToString());

                        var namedistrict = from a in db.Districts where a.DistrictId == districtId select a.DistrictName;
                        string namedistrict2 = new JavaScriptSerializer().Serialize(namedistrict);

                        string namedistrict3 = namedistrict2.Substring(2, namedistrict2.Length - 4);

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.District.ToLower().Contains(namedistrict3.ToLower()))
                                                    );
                    }
                    if (dropdownWard != null)
                    {
                        int wardId = int.Parse(dropdownWard.ToString());

                        var nameward = from a in db.Wards where a.WardId == wardId select a.WardName;
                        string nameward2 = new JavaScriptSerializer().Serialize(nameward);

                        string nameward3 = nameward2.Substring(2, nameward2.Length - 4);
                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Ward.ToLower().Contains(nameward3.ToLower()))
                                                    );
                    }
                    if (dropdownStreet != null)
                    {
                        int streetId = int.Parse(dropdownStreet.ToString());

                        var namestreet = from a in db.Streets where a.StreetId == streetId select a.StreetName;
                        string namestreet2 = new JavaScriptSerializer().Serialize(namestreet);

                        string namestreet3 = namestreet2.Substring(2, namestreet2.Length - 4);
                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Street.ToLower().Contains(namestreet3.ToLower()))
                                                    );
                    }
                    if (mode1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.ModeId == mode1)
                                                    );
                    }

                    if (areafrom1 != null)
                    {
                       

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area >= areafrom1)
                                                    );
                    }

                    if (areato1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Area <= areato1)
                                                    );
                    }

                    if (pricefrom1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price >= pricefrom1)
                                                    );
                    }

                    if (priceto1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Price <= priceto1)
                                                    );
                    }

                    if (bedroom1 != null)
                    {
                        

                        newresult = newresult.Where(c => (c.CityProvince.ToLower().Contains(namecity3.ToLower())
                                                    && c.Bedroom >= bedroom1)
                                                    );
                    }

                }
               
                var result = newresult.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 50);
               
                    return View(result);


            }


        }

        public ActionResult GetAdvSaleSeller(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 1 && s.UserId == 1 && s.ExpDate>= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvSaleAgent(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 1 && s.UserId == 2 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvBuySeller(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 2 && s.UserId == 1 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvBuyAgent(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 2 && s.UserId == 2 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvRentSeller(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 3 && s.UserId == 1 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvRentAgent(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 3 && s.UserId == 2 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvLeaseSeller(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 4 && s.UserId == 1 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }

        public ActionResult GetAdvLeaseAgent(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var getsaleseller = db.Advertisements.Where(s => s.ModeId == 4 && s.UserId == 2 && s.ExpDate >= DateTime.Now);
            var result = getsaleseller.OrderByDescending(f => f.AdvId).ToPagedList(page ?? 1, 10);
            return View(result);
        }
        public ActionResult SlideShowAgent()
        {
            return View();
        }

            //Advance Search

            public JsonResult GetModeId()
        {
            return Json(db.Modes.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCity()
        {
            return Json(db.Cities.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrict(int? cityId)
        {

            var districts = from a in db.Districts where a.CityId == cityId select a;

            return Json(districts);
        }

        public JsonResult GetWard(int? districtId)
        {


            var wards = from a in db.Wards where a.DistrictId == districtId select a;

            return Json(wards);
        }

        public JsonResult GetStreet(int? wardId)
        {


            var streets = from a in db.Streets where a.WardId == wardId select a;

            return Json(streets);
        }

        public ActionResult Detail()
        {
            var detail = db.PhotoDetails.Where(d => d.AdvId == 1);
            ViewBag.detail2 = detail;

            return View(detail);
        }


     




        public ActionResult AgentVsSeller()
        {
            var model = new SellerVsAgent();
            model.PrivateSeller = new PrivateSeller();
            model.Agent = new Agent();
            return View(model);
        }
        public ActionResult LoginAgentVsSeller()
        {
            var model = new SellerVsAgent();
            model.PrivateSeller = new PrivateSeller();
            model.Agent = new Agent();
            return View(model);
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string account, string password)
        {
            try
            {
                var seller = db.PrivateSellers.SingleOrDefault(s => s.SeLLAcount.Equals(account));
                var agent = db.Agents.SingleOrDefault(a => a.AgentAcount.Equals(account));

                if (seller != null || agent != null)
                {
                    if (seller != null)
                    {
                        if (password == seller.SellPassword)
                        {                       

                            if (seller.SellActive==false)
                            {
                                ViewBag.Msg = "Your account was deactived";
                            }
                            else
                            {
                                Session["login"] = seller.SeLLAcount;
                                Session["seller"] = seller.SeLLAcount;
                                int i = 1;

                                var expday = from a in db.Advertisements where (a.SellAcount == account) && (a.ExpDate < DateTime.Now) select a;
                                if (expday != null)
                                {

                                    foreach (var item in expday)
                                    {
                                        TempData["0"] = "( X ) Time-expired Advertisement have AdvId:";


                                        TempData[i.ToString()] = item.AdvId + " ,";
                                        i++;




                                    };


                                }


                                return RedirectToAction("Index", "Home");
                            }
                            

                        }
                        else
                        {
                            ViewBag.Msg = "Password is not exactly!";
                        }

                    }
                    else
                    {
                        if (password == agent.AgentPassword)
                        {
                            if (agent.AgentActive == false)
                            {
                                ViewBag.Msg = "Your account was deactived";
                            }
                            else
                            {
                                Session["login"] = agent.AgentAcount;
                                Session["agent"] = agent.AgentAcount;


                                int i = 1;

                                var expday = from a in db.Advertisements where (a.AgentAcount == account) && (a.ExpDate < DateTime.Now) select a;
                                if (expday != null)
                                {

                                    foreach (var item in expday)
                                    {
                                        TempData["0"] = "( X ) Time-expired Advertisement have AdvId:";


                                        TempData[i.ToString()] = item.AdvId + " ,";
                                        i++;




                                    };


                                }
                                return RedirectToAction("Index", "Home");
                            }
                           
                        }
                        else
                        {
                            ViewBag.Msg = "Password is not exactly!";
                        }

                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
                    {
                        ViewBag.Msg = "Your Password or AccountName can't empty!!";
                    }
                    else
                    {
                        ViewBag.Msg = "This account is not Existed!";
                    }

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Session.Abandon();
            if (Session["seller"] != null)
            {
                Session.Contents.Remove("seller");


            }
            else
            {
                Session.Contents.Remove("agent");
            }
            return RedirectToAction("Index", "Home");
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Agent newAgent)
        {
            var agentaccount = db.Agents.SingleOrDefault(a => a.AgentAcount.Equals(newAgent.AgentAcount));
            var selleraccount = db.PrivateSellers.SingleOrDefault(s => s.SeLLAcount.Equals(newAgent.AgentAcount));
            var agentphone = db.Agents.SingleOrDefault(p => p.AgentPhone.Equals(newAgent.AgentPhone));
            var sellerphone = db.PrivateSellers.SingleOrDefault(s => s.SellPhone.Equals(newAgent.AgentPhone));
            var agentemail = db.Agents.SingleOrDefault(e => e.AgentEmail.Equals(newAgent.AgentEmail));
            var selleremail = db.PrivateSellers.SingleOrDefault(s => s.SellEmail.Equals(newAgent.AgentEmail));
            if (ModelState.IsValid)
            {
                if (agentaccount == null && selleraccount == null)
                {

                    if (agentphone != null || sellerphone != null)
                    {
                        ViewBag.Msg = "This phone has existed already!!";
                    }
                    else if (agentemail != null || selleremail != null)

                    {
                        ViewBag.Msg = "This email has existed already!!";
                    }
                    else
                    {
                        db.Agents.Add(newAgent);
                        db.SaveChanges();
                        Session["agent"] = newAgent.AgentAcount;
                        return RedirectToAction("Index", "Home");
                        //ViewBag.Msg = "Sign Up Successfull!!";
                    }
                }
                else
                {
                    ViewBag.Msg = "This Account has exited already!!!";
                }
            }
            return View();
        }


        public ActionResult Register1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register1(PrivateSeller newSeller)
        {
            var sellaccount = db.PrivateSellers.SingleOrDefault(s => s.SeLLAcount.Equals(newSeller.SeLLAcount));
            var agentaccount = db.Agents.SingleOrDefault(a => a.AgentAcount.Equals(newSeller.SeLLAcount));
            var sellphone = db.PrivateSellers.SingleOrDefault(p => p.SellPhone.Equals(newSeller.SellPhone));
            var agentphone = db.Agents.SingleOrDefault(a => a.AgentPhone.Equals(newSeller.SellPhone));
            var sellemail = db.PrivateSellers.SingleOrDefault(e => e.SellEmail.Equals(newSeller.SellEmail));
            var agentemail = db.Agents.SingleOrDefault(a => a.AgentEmail.Equals(newSeller.SellEmail));

            if (ModelState.IsValid)
            {
                if (sellaccount == null && agentaccount == null)
                {
                    if (newSeller.SellDob > DateTime.Now)
                    {
                        ViewBag.Msg = "Date of Birth not greater than Date Now!!";
                    }
                    else if (sellphone != null || agentphone != null)
                    {
                        ViewBag.Msg = "This phone has existed already!!";
                    }
                    else if (sellemail != null || agentemail != null)

                    {
                        ViewBag.Msg = "This email has existed already!!";
                    }
                    else
                    {
                        db.PrivateSellers.Add(newSeller);
                        db.SaveChanges();
                        Session["seller"] = newSeller.SeLLAcount;
                        return RedirectToAction("Index", "Home");
                        //ViewBag.Msg = "Sign Up Successfull!!";
                    }
                }
                else
                {
                    ViewBag.Msg = "This Account has exited already!!!";
                }
            }
            return View();
        }
        public ActionResult AgentSeller()
        {
            var model = new SellerVsAgent();
            model.PrivateSeller = new PrivateSeller();
            model.Agent = new Agent();
            return View(model);
        }

        public ActionResult Feedback()
        {
            if (Session["seller"] == null && Session["agent"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.clist = new SelectList(db.Modes, "ModeId", "ModeName");
                if (Session["seller"] != null)
                {
                    string m = Session["seller"].ToString();

                    ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(s => s.SeLLAcount.Equals(m)), "SeLLId", "SeLLAcount");

                }
                else if (Session["agent"] != null)
                {
                    string m = Session["agent"].ToString();
                    ViewBag.AgentId = new SelectList(db.Agents.Where(s => s.AgentAcount.Equals(m)), "AgentId", "AgentAcount");

                }


                return View();
            }

        }
        [HttpPost]
        public ActionResult FeedBack(Feedback newFeedback)
        {

            if (Session["seller"] != null)
            {
                ViewBag.clist = new SelectList(db.Modes, "ModeId", "ModeName");
                string m = Session["seller"].ToString();

                ViewBag.SeLLId = new SelectList(db.PrivateSellers.Where(s => s.SeLLAcount.Equals(m)), "SeLLId", "SeLLAcount", newFeedback.SeLLId);

                db.Feedbacks.Add(newFeedback);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.clist = new SelectList(db.Modes, "ModeId", "ModeName");
                string m = Session["agent"].ToString();
                ViewBag.AgentId = new SelectList(db.Agents.Where(s => s.AgentAcount.Equals(m)), "AgentId", "AgentAcount", newFeedback.AgentId);

                db.Feedbacks.Add(newFeedback);


                //m.AgentId = agent.AgentId;
                //m.FeedbackContent = newFeedback.FeedbackContent;

                db.SaveChanges();
                return RedirectToAction("Index");
            }





        }

        public ActionResult FeedbackHistory()
        {
            if (Session["seller"] != null)
            {
                string m = Session["seller"].ToString();
                var seller = db.PrivateSellers.SingleOrDefault(p => p.SeLLAcount.Equals(m));
                int n = seller.SeLLId;
                var feedback = db.Feedbacks.Where(f => f.SeLLId == n);
                return View(feedback);
            }
            else if (Session["agent"] != null)
            {
                string m = Session["agent"].ToString();
                var agent = db.Agents.SingleOrDefault(p => p.AgentAcount.Equals(m));
                int n = agent.AgentId;
                var feedback = db.Feedbacks.Where(f => f.AgentId == n);
                return View(feedback);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult DisplayReply(int id)
        {
            var result = db.Feedbacks.Find(id);
            return View(result);
        }

        public ActionResult BankRate(int? m)
        {

            var result = db.Banks;
            ViewBag.oList = new SelectList(result, "BankId", "BankName", m);


            var newresult = result.Where(c => c.BankId == m);


            return View(newresult);



        }

        public ActionResult RateCalculation()
        {

            return View();


        }
        [HttpPost]
        public ActionResult RateCalculation(double principal, double rate, double amountime)
        {
            double p = principal;
            double r = (rate / 100) / 12;
            double n = amountime * 12;
            double monthlyPayment = (p * r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1);
            double m = Math.Round(monthlyPayment, 2);
            Session["m"] = m;
            return RedirectToAction("BankRate", "Home");





        }
        public ActionResult About()
        {

            return View();
        }
    }
}