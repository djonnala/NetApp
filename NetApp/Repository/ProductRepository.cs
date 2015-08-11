using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetApp.Models;

namespace NetApp.Repository
{
    public class ProductRepository
    {
        public List<HomeViewModel> GetMostPopularItems()
        {
            AdventureWorksEntities db = new AdventureWorksEntities();

            var id = (from p in db.ProductPhotoes
                      select new HomeViewModel()
                      {
                          ThumbNailPhoto = p.LargePhoto,
                          PhotoFileName = p.LargePhotoFileName
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
    }
}