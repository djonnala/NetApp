﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetApp.Models;
using System.Threading.Tasks;

namespace NetApp.Repository
{
    public class ProductRepository
    {
        AdventureWorksEntities db = new AdventureWorksEntities();

        
        public async Task<List<SubCategoriesViewModel>> GetTreeViewItems()
        {
            var tvr = new List<SubCategoriesViewModel>();
            
            var treeviewresult =  (from a in db.ProductCategories
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

        public List<CarousalViewModel> BasedOnPurchase(int customerid)
        {
            var bopmodel = new List<CarousalViewModel>();
            var boyp =  db.uspGetBasedonYourPurchase(customerid).ToList() ;
            for(int i=0;i<boyp.Count;i++)
            {
                bopmodel.Add(new CarousalViewModel() { Name = boyp[i].Name, ListPrice = boyp[i].ListPrice, ProductID = boyp[i].ProductID, ProductPhoto = boyp[i].LargePhoto });
            }
            return  bopmodel;
        }

        public int GetCustomerID(string id)
        {
            int customerid=0;
            var record = (from a in db.GetCustomerIDs
                              where a.ID == id
                              select a.CustomerID).FirstOrDefault();
            if(record!=null)
            {
                customerid = (int)record;
            }
            return customerid;
        }

        public List<CarousalViewModel> MostPopularInArea(int customerid)
        {
            var mpa = db.uspGetMostPopularInUrArea(customerid).ToList();
            var hvm = new List<CarousalViewModel>();
            for (int i = 0; i < mpa.Count; i++)
            {
                hvm.Add(new CarousalViewModel() { Name = mpa[i].Name, ListPrice = mpa[i].ListPrice, ProductPhoto = mpa[i].LargePhoto, ProductID = mpa[i].ProductID });
            }
            return hvm;
        }

        public List<CarousalViewModel> GetMostPopularItems()
        {

            var mpp = db.uspGetMostPopularProducts().ToList();
            var hvm = new List<CarousalViewModel>();
            for(int i=0;i<mpp.Count;i++)
            {
                hvm.Add(new CarousalViewModel() { Name = mpp[i].Name,ListPrice=mpp[i].ListPrice, ProductPhoto = mpp[i].LargePhoto,ProductID=mpp[i].ProductID });
            }
            
            return hvm;

    
        }


        public List<ProductViewModel> GetPeopleAlsoBought(int? productId)
        {
            
            var PAB = db.uspGetPeopleAlsoBought(productId).ToList();
            var pvm = new List<ProductViewModel>();
            
                for (int i = 0; i < PAB.Count; i++)
                {
                    pvm.Add(new ProductViewModel() { Name = PAB[i].Name, listPrice = PAB[i].ListPrice, LargePhoto = PAB[i].LargePhoto, ProductId = PAB[i].ProductID });
                }
            
            //else
            //{
            //    for(int i = 0; i < PAB.Count; i++)
            //    {
            //        pvm.Add(new ProductViewModel() { Name = PAB[i].Name, listPrice = PAB[i].ListPrice, LargePhoto = PAB[i].LargePhoto, ProductId = PAB[i].ProductID });
            //    }
            //}

            return pvm;
        }

        public List<CarousalViewModel> GetMostPopularBikes(int customerid)
        {
            var mpb = db.uspGetMpstPopularBikes(customerid).ToList();
            var hvm = new List<CarousalViewModel>();
            for(int i=0;i<mpb.Count;i++)
            {
                hvm.Add(new CarousalViewModel() { Name = mpb[i].Name, ListPrice = mpb[i].ListPrice, ProductPhoto = mpb[i].LargePhoto, ProductID = mpb[i].ProductID });
            }
            return hvm;
        }

        public List<CarousalViewModel> GetMostPopularClothing(int customerid)
        {
            var mpb = db.uspGetMpstPopularClothing(customerid).ToList();
            var hvm = new List<CarousalViewModel>();
            for (int i = 0; i < mpb.Count; i++)
            {
                hvm.Add(new CarousalViewModel() { Name = mpb[i].Name, ListPrice = mpb[i].ListPrice, ProductPhoto = mpb[i].LargePhoto, ProductID = mpb[i].ProductID });
            }
            return hvm;
        }

        public ProductViewModel GetProductDetails(int? productphotoid)
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