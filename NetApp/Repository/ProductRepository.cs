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
            

            var id = (from p in db.ProductPhotoes
                      select new HomeViewModel()
                      {
                          ThumbNailPhoto = p.LargePhoto,
                          PhotoFileName = p.LargePhotoFileName,
                          ProductPhotoId=p.ProductPhotoID
                      });
            return id.ToList();
            

            //TestDatabaseEntities db = new TestDatabaseEntities();

            //var id=(from p in db.testtables
            //       select new HomeViewModel()
            //       {
            //           Name=p.Name,
            //           Age=p.AGE
            //       });
            //return id.ToList();
        }

        public List<ProductViewModel> GetProductDetails(int productphotoid)
        {
            var id = (from p in db.ProductPhotoes
                      join q in db.ProductProductPhotoes on p.ProductPhotoID equals q.ProductPhotoID
                      join r in db.Products on q.ProductID equals r.ProductID
                      where p.ProductPhotoID == productphotoid
                      select new ProductViewModel()
                      {
                          ProductId = r.ProductID
                      });

            return id.ToList();
                         
        }

    }
}