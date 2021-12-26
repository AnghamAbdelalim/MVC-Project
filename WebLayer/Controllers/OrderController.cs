using Business_layer.AppServices;
using Business_layer.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        OrderAppService orderAppService = new OrderAppService();
        // GET: Order
        public ActionResult Index()
        {
            return View(orderAppService.GetAllOrder());
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(OrderViewModel newOrder)
        {
            if (ModelState.IsValid == false)
                return View(newOrder);
            orderAppService.SaveNewOrder(newOrder);
            return RedirectToAction("Index");
        }

      
        public ActionResult Edit(int Id)
        {
            var order = orderAppService.GetOrder(Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderViewModel newOrder,int id)
        {
            if (ModelState.IsValid==true)
            {
                orderAppService.UpdateOrder(newOrder);
               // orderAppService.SaveNewOrder(newOrder);
                return RedirectToAction("Index", orderAppService.GetAllOrder().Where(o=>o.OrderId==id));
            }
            else
            {
                return View(newOrder);
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
            orderAppService.DeleteOrder(id);
       
          return RedirectToAction("Index");
        }

      




        public ActionResult Details(int Id)
        {
            var order = orderAppService.GetOrder(Id);
            return View(order);
        }

        /*
        public ActionResult Delete(int Id)
        {
            var order = orderAppService.GetOrder(Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int Id)
        {
            var order = orderAppService.GetOrder(Id);
         
            orderAppService.DeleteOrder(Id);
            orderAppService.SaveNewOrder();
            return RedirectToAction("Index");
        }*/

        



    }
}