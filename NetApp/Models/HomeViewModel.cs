using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace NetApp.Models
{
    public class HomeViewModel
    {
        public List<CarousalViewModel> modeldata { get; set; }

        public List<CarousalViewModel> PopularBikes { get; set; }

        public List<CarousalViewModel> PopularClothing { get; set; }

        public List<SubCategoriesViewModel> Categories { get; set; }

        public List<CarousalViewModel> BasedOnPurchase { get; set; }

        public List<CarousalViewModel> MostPopularInArea { get; set; }
    }

    public class SubCategoriesViewModel
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public List<SubCategoriesViewModel> subCategories { get; set; }
    }

    public class CarousalViewModel
    {
        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        public byte[] ProductPhoto { get; set; }

        public int ProductID { get; set; }
    }

    

}