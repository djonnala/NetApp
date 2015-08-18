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

        public List<SubCategoriesViewModel> GetTreeViewItems()
        {
            var tvr = new List<SubCategoriesViewModel>();
            
            var treeviewresult = (from a in db.ProductCategories
                                  select new { a.Name, a.ProductCategoryID }).ToList();
            for(int i=0;i<treeviewresult.Count;i++)
            {
                int value = treeviewresult[i].ProductCategoryID;
                var subcategoryviewresult = (from a in db.ProductSubcategories
                                             where a.ProductCategoryID == value
                                             select a.Name).ToList();
                var subtvr = new List<SubCategoriesViewModel>();
                for (int j = 0; j < subcategoryviewresult.Count; j++)
                    subtvr.Add(new SubCategoriesViewModel() { CategoryName = subcategoryviewresult[j] });

                tvr.Add(new SubCategoriesViewModel() { CategoryName = treeviewresult[i].Name, CategoryId = treeviewresult[i].ProductCategoryID, subCategories = subtvr });
            }
            return tvr;
        }

        public List<HomeViewModel> GetSubTreeViewItems(int categoryid)
        {
            var tvr = new List<HomeViewModel>();
            var subtreeviewresult = (from a in db.ProductSubcategories
                                     where a.ProductCategoryID==categoryid
                                  select a.Name).ToList();
            for (int i = 0; i < subtreeviewresult.Count; i++)
            {
                tvr.Add(new HomeViewModel() { categories = subtreeviewresult[i] });
            }
            return tvr;
        }

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


        public void InsertNewSaleItem(int customerId,int ProductId,int Quantity)
        {
            db.uspInsertNewSaleItem(customerId, ProductId, Quantity);
        }

    }
}