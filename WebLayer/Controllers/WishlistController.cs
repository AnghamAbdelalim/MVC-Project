
using Business_layer.Bases;
using Business_layer.ViewModel;
using BusinessLayer.AppServices;
using Data_access_Layer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    [HandleError]
    [Authorize]
    public class WishlistController : Controller
    {

        WishlistAppService wishlistAppService = new WishlistAppService();
        [Authorize]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Wishlist wishlist = wishlistAppService.getWishlistByUserId(userId);
            return View(wishlist);
        }
        public ActionResult removeProduct(int productId)
        {
            string userId = User.Identity.GetUserId();
            wishlistAppService.removeProduct(userId, productId);
            TempData["Msg_Wishlist"] = "Product Removed from cart";
            return RedirectToAction("index");
        }
    }
}
