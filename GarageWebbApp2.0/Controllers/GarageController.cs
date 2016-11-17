using System;
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
        private VehicleRepository db;

        public GarageController()
        {
            db = new VehicleRepository();
        }

        public ActionResult Index()
        {
            return View(db.GetAllVehicles());
        }

        public ActionResult Details(int id)
        {
            var result = db.GetVehicleById(id);

            if (result != null)
                return View(result);

            return RedirectToAction("Error");
        }

        public ActionResult Search()
        {
            return View(db.GetAllVehicles());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string SelectionField, string SearchField)
        {
            ViewBag.Message = "new";
            var res = db.Search(SelectionField, SearchField);
            if (db.IsDataBaseEmpty() == true)
	        {
                ViewBag.Message = "IsEmpty";
                return View(db.GetAllVehicles());
	        }
            else if (res.Count() == 0)
            {
                ViewBag.Message = "IsNull";
                return View(db.GetAllVehicles());
            }
            
            return View(res);
        }

        public ActionResult Remove(int id)
        {
            if (ModelState.IsValid)
            {
                db.DeleteVehicle(id);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Parking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Parking([Bind(Include = "ItemID,RegNum,Owner,NumberOfWheels,ModelYear,Model,Color,VehicleType")] Vehicle vehicleItem)
        {
            if (ModelState.IsValid)
            {
                //var temp = db.Search("RegNum", vehicleItem.RegNum);
                //if (temp.Count()>0)
                //{
                //    ViewBag.Message = "InDB";
                //    return View(vehicleItem);
                //}

                db.AddVehicle(vehicleItem);
                return RedirectToAction("Index");
            }

            return View(vehicleItem);
        }

        public JsonResult ListVehicles(string filter)
        {
            List<string> VehicleTypes = new List<string>();
            List<string> VehicleColors = new List<string>();
            FilterViewModels obj = JsonConvert.DeserializeObject<FilterViewModels>(filter);

            foreach (var item in obj.VehicleTypes)
                if (item.Value)
                    VehicleTypes.Add(item.Key);

            foreach (var item in obj.VehicleColors)
                if (item.Value)
                    VehicleColors.Add(item.Key);

            return Json(db.GetVehicleView(VehicleTypes, VehicleColors), JsonRequestBehavior.AllowGet);
        }

        public string GetFilters()
        {
            return JsonConvert.SerializeObject(new FilterViewModels());
        }
    }
}