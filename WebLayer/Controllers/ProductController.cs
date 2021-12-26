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
    public class ProductController : Controller
    {
        // GET: Product
        ProductAppService productAppService = new ProductAppService();
        CategoryAppService categoryAppService = new CategoryAppService();
        public ActionResult Index()
        {
            return View(productAppService.GetAllProduct());
        }
        
        public ActionResult ShowProduct()
        {
            return View(productAppService.GetAllProduct());
        }
        public ActionResult DetailsProduct(int id)
        {
            return View(productAppService.GetProduct(id));
        }
        [HttpGet]
        public ActionResult NewProduct() => View();
        [HttpPost]
        public ActionResult NewProduct( productViewModel productViewModel)
        {
            if (productViewModel.ProductName != "" && productViewModel.ProductName != null)
            {

                productAppService.SaveNewProduct(productViewModel);
                return RedirectToAction("Index");
            }
            return View("NewProduct");
        }
        [HttpGet]
        public ActionResult updateProduct(int id)
        {

            var Product= productAppService.GetProduct(id);
            return View(Product);
        }
        [HttpPost]
        public ActionResult updateProduct(productViewModel productViewModel)
        {

            productAppService.UpdateProduct(productViewModel);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            productAppService.DeleteProduct(id);
            return RedirectToAction("index");
        }

        /*public ActionResult Search(string ProductName)
        {
            var product = productAppService.GetAllProduct();
            product.Contains(ProductName);
            return View("Index", pro);
        }*/
        /*public ActionResult Search(string Name)
        {

            ViewBag.Name = Name;
           var  product= productAppService.GetAllProduct();
             foreach(productViewModel prod in product)
            {
                if(Name==prod.ProductName)
                {
                    return View("Search",prod);
                }
            }
            return View("ShowProduct");
        }*/
       
     
        public ActionResult Search(string proName)
        {
            ViewBag.categories = productAppService.GetAllProduct();
            List<productViewModel> productViewModels = productAppService.Search(proName);
            return View("Search", productViewModels);
        }
    }
}