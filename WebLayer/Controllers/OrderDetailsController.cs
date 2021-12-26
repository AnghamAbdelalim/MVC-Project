using Business_layer.AppServices;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
   // [Authorize]
    public class OrderDetailsController : Controller
    {
        OrderDetailsAppService orderDetailsAppService = new OrderDetailsAppService();
        // GET: Order
        public ActionResult Index()
        {
            return View(orderDetailsAppService.GetAllOrderDetails());
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(OrderDetailsViewModel newOrderDetail)
        {
            if (ModelState.IsValid == false)
                return View(newOrderDetail);
            orderDetailsAppService.SaveNewOrdeDetails(newOrderDetail);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {
            var order = orderDetailsAppService.GetOrderDetails(Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderDetailsViewModel newOrderDetail)
        {
            if (ModelState.IsValid)
            {
                orderDetailsAppService.UpdatOrdeDetails(newOrderDetail);
              //  orderDetailsAppService.SaveNewOrdeDetails(newOrderDetail);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newOrderDetail);
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

            orderDetailsAppService.DeleteOrderDetails(id);
            return RedirectToAction("Index");
        }



        public ActionResult Details(int Id)
        {
            var order = orderDetailsAppService.GetOrderDetails(Id);
            return View(order);
        }

     

      




    }
}