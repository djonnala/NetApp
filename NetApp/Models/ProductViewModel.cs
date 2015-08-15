using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace NetApp.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string color { get; set; }

        public string size { get; set; }

        public decimal listPrice { get; set; }

        public string Weight { get; set; }

        public string description { get; set; }

        public byte[] LargePhoto { get; set; }


        public List<ProductViewModel> PeopleAlsoBought { get; set; }

    }
}