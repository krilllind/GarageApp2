using Garage3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage3.Controllers
{
    public class AngularJSController : Controller
    {
        private VehicleRepository _repo;
        // GET: AngularJS

        public AngularJSController()
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

        public JsonResult GetOwner(string id)
        {
            return Json(_repo.GetOwner(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllVehicles()
        {
            return Json(_repo.GetVehicles(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehicle(string id)
        {
            return Json(_repo.GetVehicle(id), JsonRequestBehavior.AllowGet);
        }
    }
}