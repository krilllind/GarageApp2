using Garage3.Models;
using Garage3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage3.Controllers
{
    public class GarageController : Controller
    {
        private VehicleRepository _repo;
        // GET: AngularJS

        public GarageController()
        {
            _repo = new VehicleRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllOwners()
        {
            return Json(_repo.GetOwners(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllVehicles()
        {
            return Json(_repo.GetVehicles(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOwner(Owner owner)
        {
            _repo.Add(owner);
            if (_repo.GetOwners().Where(c=>c.Name == owner.Name && c.Owner_ID == owner.Owner_ID).Any())
            {
                return Json(new { owner });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult AddVehicle(Vehicle vehicle)
        {
            _repo.Add(vehicle);

            if (_repo.GetVehicles().Where(c => c.Vehicle_ID == vehicle.Vehicle_ID).Any())
            {
                return Json(new { vehicle });
            }
            return Json(new { success = false });
        }

        public void EditOwner(Owner owner)
        {
            _repo.Edit(owner);
        }

        public void EditVehicle(Vehicle vehicle)
        {
            _repo.Edit(vehicle);
        }

        [HttpPost]
        public void DeleteOwner(Owner owner)
        {
            _repo.Remove(owner);
        }

        [HttpPost]
        public void DeleteVehicle(Vehicle vehicle)
        {
            _repo.Remove(vehicle);
        }
    }
}