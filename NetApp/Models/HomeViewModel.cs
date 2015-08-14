using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace NetApp.Models
{
    public class HomeViewModel
    {
        public int productId { get; set; }

        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        //public string ProductName { get; set; }

        //public string ProductPrice { get; set; }

        //public Image ProductImage { get; set; }

        public int ProductPhotoId { get; set; }


        public byte[] ThumbNailPhoto { get; set; }


        public List<HomeViewModel> modeldata { get; set; }

        public List<HomeViewModel> PopularBikes { get; set; }

        public List<HomeViewModel> PopularClothing { get; set; }
    }
}