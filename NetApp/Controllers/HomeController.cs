using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetApp.Models;
using NetApp.Repository;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace NetApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (User.Identity.GetUserId() != null)
            {
                
                var productRepository = new ProductRepository();
                var HomeItems = new HomeViewModel();
                int customerid = productRepository.GetCustomerID(User.Identity.GetUserId());
                var tvr = await productRepository.GetTreeViewItems();
                var id = productRepository.GetMostPopularItems();
                var pb = productRepository.GetMostPopularBikes(customerid);
                var pc = productRepository.GetMostPopularClothing(customerid);
                var boyp = productRepository.BasedOnPurchase(customerid);
                var mpa = productRepository.MostPopularInArea(customerid);
                
                HomeItems.MostPopularInArea = mpa;
                HomeItems.BasedOnPurchase = boyp;
                HomeItems.PopularClothing = pc;
                HomeItems.PopularBikes = pb;
                HomeItems.Categories = tvr;
                HomeItems.modeldata = id;

                return View(HomeItems);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

       

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AutoComplete(string term)
        {
            AdventureWorksEntities db = new AdventureWorksEntities();
            var result = (from b in db.Products
                          where b.Name.Contains(term)
                          select new { b.Name,b.ProductID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
   
       [HttpGet]
        public ActionResult About( int? id)
        {
            if (User.Identity.GetUserId() != null)
            {
                var productRepository = new ProductRepository();
                var pvm = new ProductViewModel();

                var gpab = productRepository.GetPeopleAlsoBought(id);

                pvm.PeopleAlsoBought = gpab;
                var idprod = productRepository.GetProductDetails(id);

                pvm.LargePhoto = idprod.LargePhoto;
                pvm.listPrice = idprod.listPrice;
                pvm.Name = idprod.Name;
                pvm.ProductId = idprod.ProductId;
                pvm.color = idprod.color;
                pvm.Weight = idprod.Weight;
                pvm.size = idprod.size;
                pvm.description = idprod.description;
                ViewBag.Message = "Your application description page.";

                return View(pvm);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult About(ProductViewModel pvm)
        {
            var productRepository = new ProductRepository();
            int productid = pvm.ProductId;
            int customerid = productRepository.GetCustomerID(User.Identity.GetUserId()); ;
            int quantity = pvm.quantity;
            var idprod = productRepository.GetProductDetails(productid);
            pvm.LargePhoto = idprod.LargePhoto;
            pvm.listPrice = idprod.listPrice;
            pvm.Name = idprod.Name;
            pvm.color = idprod.color;
            pvm.Weight = idprod.Weight;
            pvm.size = idprod.size;
            pvm.description = idprod.description;
            var gpab = productRepository.GetPeopleAlsoBought(productid);

            pvm.PeopleAlsoBought = gpab;


            productRepository.InsertNewSaleItem(customerid, productid, quantity);
            return View(pvm);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}