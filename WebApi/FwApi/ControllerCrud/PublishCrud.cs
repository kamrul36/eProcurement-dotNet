using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.ViewModel;
using FwCore.DBContext.Repository;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    public class PublishCrud : PublishRepo
    {
        AppDataDbContext dbase;
        public PublishCrud(AppDataDbContext _db)
        {
            dbase = _db;
        }

        public async Task<List<PublishTenderViewModel>> PublishTenders()
        {
            if (dbase != null)
            {
                return await (from t in dbase.tenders
                              join p in dbase.ProductLists
                              on t.TenderID equals p.TenderID
                              join c in dbase.tenderCategories
                              on t.CatId equals c.CatId

                              select new PublishTenderViewModel
                              {
                               
                                 
                                  TenderTitle= p.ProductTitle,
                                  TenderCategory = c.CategoryType


                              }).ToListAsync();
            }

            return null;


        }


        public async Task<PublishTenderViewModel> PublishTender(int? tenderID)
        {
            if (dbase != null)
            {
                return await (from t in dbase.tenders
                              join p in dbase.ProductLists
                              on t.TenderID equals p.TenderID
                              join c in dbase.tenderCategories
                              on t.CatId equals c.CatId

                              select new PublishTenderViewModel
                              {
                               
                                 
                                  TenderTitle = p.ProductTitle,
                                  TenderCategory = c.CategoryType


                              }).FirstOrDefaultAsync();
            }

            return null;
        }
    }
}
