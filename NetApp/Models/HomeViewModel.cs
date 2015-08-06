using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace NetApp.Models
{
    public class HomeViewModel
    {
        //public string ProductName { get; set; }

        //public string ProductPrice { get; set; }

        //public Image ProductImage { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public byte[] ThumbNailPhoto { get; set; }

        public Image Photo { get; set; }

        public string ThumbnailPhotoFileName { get; set; }
    }
}