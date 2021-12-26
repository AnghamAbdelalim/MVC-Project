using Business_layer.AppServices;
using Business_layer.ViewModel;
using Data_access_Layer;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using System;
using Microsoft.Owin.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
   //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        AccountAppService accountAppService = new AccountAppService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(RegisterViewodel admin)
        {
            if (ModelState.IsValid == false)
            {
                return View(admin);
            }

            IdentityResult result = accountAppService.Register(admin);
            if (result.Succeeded)
            {
                ApplicationUserIdentity identityUser = accountAppService.Find(admin.UserName, admin.PasswordHash);
               
                accountAppService.AssignToRole(identityUser.Id, "Admin");
                return RedirectToAction("NewRole", "Admin");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(admin);
            }
        }
        public ActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(string RoleName)
        {
            RoleAppService role = new RoleAppService();
            //if (RoleName != null)
            // {
            //Save Db
            //role.Create(RoleName);
            // IdentityResult result = manager.Create(role);
            // if (Succeeded)
           // {
               role.Create(RoleName);
               return RedirectToAction("Index");
               // }
              //  ViewBag.Error2 = result.Errors;
           // }
            //else
            //{
                //ViewBag.Error1 = "Role Cant BE Empty";
            //}
            //ViewBag.RoleName = RoleName;
           // return View();
        }

    }
}