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
        public ActionResult Index()
        {
            var productRepository = new ProductRepository();

            var productViewModel = new HomeViewModel();

            var id = productRepository.GetMostPopularItems();
            productViewModel.ThumbNailPhoto = id[1].ThumbNailPhoto;
            productViewModel.Photo = byteArraytoImage(id[1].ThumbNailPhoto);
            return View(productViewModel);
        }

        public FileContentResult getImg(byte[] bytearray)
        {
            return bytearray != null
                ? new FileContentResult(bytearray, "image/jpeg")
                : null;
        }
        public  Image byteArraytoImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}