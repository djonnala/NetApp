using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace NetApp.Models
{
    public class HomeViewModel
    {

        public string categories { get; set; }

        public int productcategoryid { get; set; }

      //  public string subcategories { get; set; }

        public int productId { get; set; }

        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        public int ProductPhotoId { get; set; }


        public byte[] ThumbNailPhoto { get; set; }


        public List<HomeViewModel> modeldata { get; set; }

        public List<HomeViewModel> PopularBikes { get; set; }

        public List<HomeViewModel> PopularClothing { get; set; }

        public List<SubCategoriesViewModel> Categories { get; set; }

        public List<HomeViewModel> BasedOnPurchase { get; set; }

        public List<HomeViewModel> MostPopularInArea { get; set; }
    }

    public class SubCategoriesViewModel
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public List<SubCategoriesViewModel> subCategories { get; set; }
    }


}