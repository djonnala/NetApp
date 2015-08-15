using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetApp.Models;
using NetApp.Repository;
using System.Drawing;
using System.IO;

namespace NetApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var productRepository = new ProductRepository();

            var MostPopularItems = new HomeViewModel();

            var id = productRepository.GetMostPopularItems();

            var pb = productRepository.GetMostPopularBikes();

            var pc = productRepository.GetMostPopularClothing();

            MostPopularItems.PopularClothing = pc;
            
            MostPopularItems.PopularBikes = pb;
            

            MostPopularItems.modeldata = id;
            return View(MostPopularItems);
        }
   
        //public  Image byteArraytoImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
        public ActionResult About( int id)
        {
            var productRepository = new ProductRepository();
            var pvm = new ProductViewModel();

            var gpab = productRepository.GetPeopleAlsoBought(id);

            pvm.PeopleAlsoBought = gpab;
            var idprod = productRepository.GetProductDetails(id);
           // idprod.LargePhotodisplay = byteArraytoImage(idprod.LargePhoto);
            pvm.LargePhoto = idprod.LargePhoto;
            pvm.listPrice = idprod.listPrice;
            pvm.Name = idprod.Name;
            pvm.ProductId = idprod.ProductId;
            pvm.color = idprod.color;
            pvm.Weight = idprod.Weight;
            pvm.size = idprod.size;
            ViewBag.Message = "Your application description page.";

            return View(pvm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}