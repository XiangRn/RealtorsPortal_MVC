using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorsPortalSystem.Models;

namespace RealtorsPorttalSystem.Controllers
{
    public class AdvertisementsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        public ActionResult ThumbnailDetails(int id)
        {

            var detail = db.PhotoDetails.Where(d => d.AdvId == id);
            return View(detail);
        }
    }
}
