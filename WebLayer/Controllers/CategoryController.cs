using Business_layer.AppServices;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLay.Controllers
{
    public class CategoryController : Controller
    {
        CategoryAppService categoryAppservice = new CategoryAppService();
        public ActionResult Index()
        {
            return View(categoryAppservice.GetAllCategory());
        }
        public ActionResult NewCategory() => View();
        [HttpPost]
        public ActionResult NewCategory(categoryViewModelcs newCategory)
        {
            categoryAppservice.SaveNewCategory(newCategory);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult updateCategory(int id)
        {
             
            var Category=categoryAppservice.GetCategory(id);
            return View(Category);
        }
        [HttpPost]
        public ActionResult updateCategory(categoryViewModelcs updateCategory)
        {
            categoryAppservice.UpdateCategory(updateCategory);
            return RedirectToAction("Index");
        }
     
        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            categoryAppservice.DeleteCategory(id);
            return RedirectToAction("Index");

        }
    }
}