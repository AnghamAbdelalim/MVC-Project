using Business_layer.Bases;
using Business_layer.ViewModel;
using Business_Layer.AppServices;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace WebLayer.Controllers
{
        //[Authorize]
        public class PaymentController : Controller
        {
            PaymentAppService paymentAppService = new PaymentAppService();

            public ActionResult Index()
            {
                return View(paymentAppService.GetAllPayments());
            }
        /*public ActionResult AllPayment()
        {

            ViewBag.payments = paymentAppService.GetAllPayments();
            return View(paymentAppService.GetAllPayments());
        }*/
            [HttpGet]
            public ActionResult Create() => View();
            [HttpPost]
            public ActionResult Create(PaymentViewModel paymentViewModel)
            {
                paymentViewModel.UserId = User.Identity.GetUserId();
                ViewBag.payments = paymentAppService.GetAllPayments();
                if (ModelState.IsValid == false)
                    return RedirectToAction("index"); //to be modfied and pass rigth CartPaymentInfoVieModel

                paymentAppService.SaveNewPayment(paymentViewModel);

                return RedirectToAction("index");
            }

            public ActionResult UpdatePayment(int ID)
            {
                PaymentViewModel paymentView = paymentAppService.GetPayment(ID);
                ViewBag.payments = paymentAppService.GetAllPayments();
                return View(paymentView);
            }

            public ActionResult UpdatePayment(PaymentViewModel paymentView)
            {

                paymentAppService.UpdatePayment(paymentView);
                return RedirectToAction("Index");
            }
            public ActionResult DeletePayment(int ID)
            {
                paymentAppService.DeletePayment(ID);
                return RedirectToAction("Index");
            }
        }
    }
