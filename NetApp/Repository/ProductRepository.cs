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




            //var mostpp = new HomeViewModel();
            //var mpp = db.uspGetMostPopularProducts().ToList();

            //mostpp.Name = mpp[1].Name;

            //return mostpp;

            //var id = (from p in db.ProductPhotoes
            //          select new HomeViewModel()
            //          {
            //              ThumbNailPhoto = p.LargePhoto,
            //              PhotoFileName = p.LargePhotoFileName,
            //              ProductPhotoId=p.ProductPhotoID
            //          });
            //return id.ToList();
    
        }

        public ProductViewModel GetProductDetails(int productphotoid)
        {
            var productdetails = db.uspGetProductDeatils(762);

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