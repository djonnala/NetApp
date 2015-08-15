using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetApp.Models;

namespace NetApp.Repository
{
    public class ProductRepository
    {
        AdventureWorksEntities db = new AdventureWorksEntities();
        public List<HomeViewModel> GetMostPopularItems()
        {

            var mpp = db.uspGetMostPopularProducts().ToList();
            var hvm = new List<HomeViewModel>();
            for(int i=0;i<10;i++)
            {
                hvm.Add(new HomeViewModel() { Name = mpp[i].Name,ListPrice=mpp[1].ListPrice,ThumbNailPhoto=mpp[i].LargePhoto,productId=mpp[i].ProductID });
            }
            
            return hvm;

    
        }


        public List<ProductViewModel> GetPeopleAlsoBought(int productId)
        {
            
            var PAB = db.uspGetPeopleAlsoBought(productId).ToList();
            var pvm = new List<ProductViewModel>();

            for(int i=0;i<10;i++)
            {
                pvm.Add(new ProductViewModel() { Name = PAB[i].Name, listPrice = PAB[i].ListPrice, LargePhoto = PAB[i].LargePhoto, ProductId = PAB[i].ProductID });
            }

            return pvm;
        }

        public List<HomeViewModel> GetMostPopularBikes()
        {
            var mpb = db.uspGetMpstPopularBikes().ToList();
            var hvm = new List<HomeViewModel>();
            for(int i=0;i<10;i++)
            {
                hvm.Add(new HomeViewModel() { Name = mpb[i].Name, ListPrice = mpb[i].ListPrice, ThumbNailPhoto = mpb[i].LargePhoto, productId = mpb[i].ProductID });
            }
            return hvm;
        }

        public List<HomeViewModel> GetMostPopularClothing()
        {
            var mpb = db.uspGetMpstPopularClothing().ToList();
            var hvm = new List<HomeViewModel>();
            for (int i = 0; i < 10; i++)
            {
                hvm.Add(new HomeViewModel() { Name = mpb[i].Name, ListPrice = mpb[i].ListPrice, ThumbNailPhoto = mpb[i].LargePhoto, productId = mpb[i].ProductID });
            }
            return hvm;
        }

        public ProductViewModel GetProductDetails(int productphotoid)
        {
            var productdetails = db.uspGetProductDeatils(productphotoid);

            var prodetails = new ProductViewModel();

            foreach (uspGetProductDeatils_Result pv in productdetails.ToList())
            {
                prodetails.ProductId = pv.ProductID;
                prodetails.size = pv.Size;
                prodetails.Weight = pv.Weight;
                prodetails.listPrice = pv.ListPrice;
                prodetails.LargePhoto = pv.LargePhoto;
                prodetails.description = pv.Description;
                prodetails.color = pv.Color;
                prodetails.Name = pv.Name;
            }
            
            
            return prodetails;

                         
        }

    }
}