﻿using Business_layer.AppServices;
using Business_layer.ViewModel;
using Data_access_Layer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebLayer.Controllers
{
    public class AccountController : Controller
    {

        AccountAppService accountAppService = new AccountAppService();
        // GET: Account
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(RegisterViewodel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            IdentityResult result = accountAppService.Register(user);
            if (result.Succeeded)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signinmanager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                ApplicationUserIdentity identityUser = accountAppService.Find(user.UserName, user.PasswordHash);
                signinmanager.SignIn(identityUser, true, true);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(user);
            }
        }
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            ApplicationUserIdentity identityUser = accountAppService.Find(user.UserName, user.PasswordHash);

            if (identityUser != null)
            {
               
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signinmanager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                signinmanager.SignIn(identityUser, true, true);
                return RedirectToAction("ShowProduct", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(user);
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

    }
}