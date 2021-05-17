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
namespace RealtorsPortalSystem.Controllers
{
    public class AgentsController : Controller
    {
        private RealtorsPortal db = new RealtorsPortal();

        // GET: Agents
        public ActionResult Index()
        {
            string agent = Session["agent"].ToString();
            return View(db.Agents.Where(s => s.AgentAcount.Equals(agent)).ToList());
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentId,AgentAcount,AgentName,AgentPassword,AgentAddress,AgentPhone,AgentEmail,TaxCode")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agent agent, HttpPostedFileBase file)
        {
            var adv = db.Agents.SingleOrDefault(
                    p => p.AgentId.Equals(agent.AgentId));
            
             if(file==null)
            {
                adv.AgentAvatar = adv.AgentAvatar;
            }else if(file.ContentLength > 0)
            {
                string pathFile = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("/Lmages"), pathFile);
                file.SaveAs(path);
                adv.AgentAvatar = "/Lmages/" + pathFile;
            }
            
          
            if (ModelState.IsValid)
            {
                adv.AgentAcount = agent.AgentAcount;
                adv.AgentAddress = agent.AgentAddress;
                adv.AgentEmail = agent.AgentEmail;
                adv.AgentName = agent.AgentName;
                adv.AgentPhone = agent.AgentPhone;
                adv.TaxCode = agent.TaxCode;
                adv.AgentPassword = agent.AgentPassword;
                Session["agent"] = agent.AgentAcount;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
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
