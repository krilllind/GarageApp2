using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage3.DataAccesLayer;
using Garage3.Models;
using Garage3.Repositories;
namespace Garage3.Controllers
{
    public class OwnersController : Controller
    {
        private OwnerWehicleContext db = new OwnerWehicleContext();
        private VehicleRepository Repo = new VehicleRepository();
        // GET: Owners
        public ActionResult Index()
        {
            return View(Repo.GetOwners());
        }

        // GET: Owners/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = Repo.GetOwner(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Owner_ID,Name")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                if (Repo.GetOwner(owner.Owner_ID) != null)
                {
                    return View(owner);
                }
                else
                {
                    Repo.Add(owner);
                    return RedirectToAction("Index");
                }
                
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = Repo.GetOwner(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Owner_ID,Name")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                Repo.Edit(owner);
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = Repo.GetOwner(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Owner owner = Repo.GetOwner(id);
            Repo.Remove(owner);
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
