using Business_layer.AppServices;
using  Business_layer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class ShipperController : Controller
    {
        ShipperAppService shipperAppService = new ShipperAppService() ;
        // GET: Order
        public ActionResult Index()
        {
            return View(shipperAppService.GetAllShipper());
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(ShipperViewModel newshipper)
        {
            if (ModelState.IsValid == false)
                return View(newshipper);
            shipperAppService.SaveNewShipper(newshipper);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {
            var shipper = shipperAppService.GetShipper(Id);
            return View(shipper);
        }

        [HttpPost]
        public ActionResult Edit(ShipperViewModel newshipper)
        {
           
            if (ModelState.IsValid)
            {
                shipperAppService.UpdatShipper(newshipper);
                //shipperAppService.SaveNewShipper(newshipper);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newshipper);
            }
        }

        /*[HttpGet]
        public ActionResult Delete()
        {
            return View();
        }*/
        [HttpPost]
        public ActionResult Delete(int id)
        {

            shipperAppService.DeleteShipper(id);
            return RedirectToAction("Index");
        }



        public ActionResult Details(int Id)
        {
            var shipper = shipperAppService.GetShipper(Id);
            return View(shipper);
        }

      




    }
}