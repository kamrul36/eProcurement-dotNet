using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.ViewModel;
using FwCore.DBContext.Repository;
using FwCore.DBContext;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.ControllerCrud
{
    public class InterfaceCrud : InterfaceRepo
    {
        AppDataDbContext db;

        public InterfaceCrud(AppDataDbContext _db)
        {
            db = _db;
        }

        public async Task<List<ProjectShowViewModel>> ShowTenders()
        {
            if (db != null)
            {
                return await (from t in db.tenders
                              join p in db.ProductLists
                              on t.TenderID equals p.TenderID
                              join c in db.tenderCategories
                              on t.CatId equals c.CatId
                              join y in db.tenderTypes
                              on t.ProcurementId equals y.ProcurementId
                             

                              select new ProjectShowViewModel
                              {
                                  tenderID =t.TenderID,
                                  TenderTitle = t.TenderTitle,
                                  Category = c.CategoryType,
                                  Description= p.Discription,
                                  Type = y.ProcurementType,
                                  TenderBeginDate =t.BeginDate,
                                  TenderSubmitEndDate =t.EndDate


                              }).ToListAsync();
            }

            return null;


        }


        public async Task<ProjectShowViewModel> ShowTender(int? tenderID)
        {
            if (db != null)
            {
                return await (from t in db.tenders
                              join p in db.ProductLists
                              on t.TenderID equals p.TenderID
                              join c in db.tenderCategories
                              on t.CatId equals c.CatId
                              join y in db.tenderTypes
                              on t.ProcurementId equals y.ProcurementId


                              select new ProjectShowViewModel
                              {
                                  tenderID = t.TenderID,
                                  TenderTitle = t.TenderTitle,
                                  Category = c.CategoryType,
                                  Description = p.Discription,
                                  Type = y.ProcurementType,
                                  TenderBeginDate = t.BeginDate,
                                  TenderSubmitEndDate = t.EndDate


                              }).FirstOrDefaultAsync();
            }

            return null;


        }
    }
}
