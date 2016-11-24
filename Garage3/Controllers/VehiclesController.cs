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
    public class VehiclesController : Controller
    {
        private OwnerWehicleContext db = new OwnerWehicleContext();
        private VehicleRepository Repo = new VehicleRepository();
        // GET: Vehicles
        public ActionResult Index()
        {
            //var vehicles = db.Vehicles.Include(v => v.Owner).Include(v => v.VehicleType);
            //var d = db.Vehicles.Include(v => v.)
            return View(Repo.GetVehicles());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.Owner_ID = new SelectList(db.Owners, "Owner_ID", "Name");
            ViewBag.Type = new SelectList(db.VehicleTypes, "VehicleType_Id", "Name");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vehicle_ID,Owner_ID,Type")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Owner_ID = new SelectList(db.Owners, "Owner_ID", "Name", vehicle.Owner_ID);
            ViewBag.Type = new SelectList(db.VehicleTypes, "VehicleType_Id", "Name", vehicle.Type);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Owner_ID = new SelectList(db.Owners, "Owner_ID", "Name", vehicle.Owner_ID);
            ViewBag.Type = new SelectList(db.VehicleTypes, "VehicleType_Id", "Name", vehicle.Type);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vehicle_ID,Owner_ID,Type")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Owner_ID = new SelectList(db.Owners, "Owner_ID", "Name", vehicle.Owner_ID);
            ViewBag.Type = new SelectList(db.VehicleTypes, "VehicleType_Id", "Name", vehicle.Type);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
