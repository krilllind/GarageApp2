﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GarageWebbApp2._0.Repositories;
using GarageWebbApp2._0.Models;
using Newtonsoft.Json;

namespace GarageWebbApp2._0.Controllers
{
    public class GarageController : Controller
    {
        private VehicleRepository _repo;

        public GarageController()
        {
            _repo = new VehicleRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parking()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult GetAllOwners()
        {
            return Json(_repo.GetAllOwners(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllVehicles()
        {
            return Json(_repo.GetAllVehicles(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehicle(string data)
        {
            return Json(_repo.GetVehicle(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllVehicleTypes()
        {
            return Json(_repo.GetAllVehiclesTypes(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllVehicleColors()
        {
            return Json(_repo.GetAllVehicleColors(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOwner(Owner owner)
        {
            _repo.Add(owner);

            if (_repo.GetAllOwners().Where(c => c.Name == owner.Name && c.Owner_ID == owner.Owner_ID).Any())
            {
                return Json(new { owner });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult AddVehicle(Vehicle data)
        {
            data.Owner = _repo.GetOwner(data.Owner_ID);
            data.VehicleType = _repo.GetAllVehiclesTypes().Single(t => t.VehicleType_Id == data.Type);

            if (_repo.Add(data))
                return Json(new { data });

            Response.StatusCode = 400;
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult DeleteVehicle(string data)
        {
            if (_repo.Remove(data))
                return Json(new { data });

            Response.StatusCode = 400;
            return Json(new { success = false });
        }

        public string GetFilters()
        {
            return JsonConvert.SerializeObject(new FilterViewModels());
        }
    }
}