using FwCore.DBContext;
using FwCore.DBContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwApi.Controllers
{
    public class TenderCrud :IRepository
    {
        AppDataDbContext db;
        public TenderCrud(AppDataDbContext _db)
        {
            db = _db;
        }

        //public async Task<List<Category>> GetCategories()
        //{
        //    if (db != null)
        //    {
        //        return await db..ToListAsync();
        //    }

        //    return null;
        //}

        public async Task<List<TenderViewModel>> GetTenders()
        {
            if (db != null)
            {
                return await (from t in db.tenders

                              join p in db.ProductLists
                              on t.TenderID equals p.TenderID
                              join s in db.statuses
                              on t.StatusID equals s.StatusID
                              join e in db.tenderTypes
                              on t.ProcurementId equals e.ProcurementId
                              join c in db.tenderCategories
                             on t.CatId equals c.CatId
                              join o in db.tenderProducts
                              on t.TenderID equals o.TenderID

                              select new TenderViewModel
                              {
                                  TenderID = t.TenderID,
                                  TenderRefNumber=t.TenderRefNumber,
                                  TenderTitle =t.TenderTitle,
                                  DocumentUpdload = t.DocumentUpdload,
                                  BeginDate = t.BeginDate,
                                  EndDate = t.EndDate,
                                  PaymentType = t.PaymentType,
                                  IsActive = t.IsActive,
                                  ContactType = t.ContactType,
                                  Location = t.Location,
                                  
                                  BidOpeningDate = t.BidOpeningDate,
                                  BidClosingDate = t.BidClosingDate,
                                  ProductName = p.ProductName,
                                  ProductTitle = p.ProductTitle,
                                  Quantity = p.Quentity,
                                  Description = p.Discription,
                                  ProductCategory = p.ProductCategory,
                                  StatusType = s.StatusType,
                                  ProcurementType = e.ProcurementType,
                                  CategoryType = c.CategoryType,
                                  TGoodsName = o.TGoodsName,
                                  PTotalCost=t.PTotalCost
                                  


                              }).ToListAsync();
            }

            return null;
        }

        public async Task<TenderViewModel> GetTender(int? tenderID)
        {
            if (db != null)
            {
                return await (from t in db.tenders

                              join p in db.ProductLists
                            on t.TenderID equals p.TenderID
                              join s in db.statuses
                              on t.StatusID equals s.StatusID
                              join e in db.tenderTypes
                              on t.ProcurementId equals e.ProcurementId
                              join c in db.tenderCategories
                             on t.CatId equals c.CatId
                              join o in db.tenderProducts
                            on t.TenderID equals o.TenderID

                              select new TenderViewModel
                              {
                                  TenderID = t.TenderID,
                                  TenderRefNumber = t.TenderRefNumber,
                                  TenderTitle = t.TenderTitle,
                                  DocumentUpdload = t.DocumentUpdload,
                                  BeginDate = t.BeginDate,
                                  EndDate = t.EndDate,
                                  PaymentType = t.PaymentType,
                                  IsActive = t.IsActive,
                                  ContactType = t.ContactType,
                                  Location = t.Location,
                                 
                                  BidOpeningDate = t.BidOpeningDate,
                                  BidClosingDate = t.BidClosingDate,
                                  ProductName = p.ProductName,
                                  ProductTitle = p.ProductTitle,
                                  Quantity = p.Quentity,
                                  Description = p.Discription,
                                  ProductCategory = p.ProductCategory,
                                  StatusType = s.StatusType,
                                  ProcurementType = e.ProcurementType,
                                  CategoryType = c.CategoryType,
                                  TGoodsName = o.TGoodsName,
                                    PTotalCost = t.PTotalCost
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        //public async Task<TenderViewModel> AddTender(int tenderid)
        //{
        //    if (db != null)
        //    {
        //        return await (from t in db.tenders

        //                      join p in db.ProductLists
        //                    on t.TenderID equals p.TenderID
        //                      join s in db.statuses
        //                      on t.StatusID equals s.StatusID
        //                      join e in db.tenderTypes
        //                      on t.ProcurementId equals e.ProcurementId
        //                      join c in db.tenderCategories
        //                     on t.CatId equals c.CatId

        //                      select new TenderViewModel
        //                      {
        //                          tenderID = t.TenderID,
        //                          TenderRefNumber = t.TenderRefNumber,
        //                          DocumentUpdload = t.DocumentUpdload,
        //                          BeginDate = t.BeginDate,
        //                          EndDate = t.EndDate,
        //                          PaymentType = t.PaymentType,
        //                          IsActive = t.IsActive,
        //                          ContactType = t.ContactType,
        //                          Location = t.Location,
        //                          BidOpeningDate = t.BidOpeningDate,
        //                          BidClosingDate = t.BidClosingDate,
        //                          ProductName = p.ProductName,
        //                          ProductTitle = p.ProductTitle,
        //                          Quantity = p.Quentity,
        //                          Description = p.Discription,
        //                          ProductCategory = p.ProductCategory,
        //                          StatusType = s.StatusType,
        //                          ProcurementType = e.ProcurementType,
        //                          CategoryType = c.CategoryType


        //                      }).FirstOrDefaultAsync();
        //    }

        //    return null;
        //}



        public async Task<int> AddTender(Tenders tender)
        {
            if (db != null)
            {
                await db.tenders.AddAsync(tender);
                await db.SaveChangesAsync();

                return tender.TenderID;
            }

            return 0;
        }

        public async Task<int> DeleteTender(int? Tenderid)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var tender = await db.tenders.FirstOrDefaultAsync(x => x.TenderID == Tenderid);

                if (tender != null)
                {
                    //Delete that post
                    db.tenders.Remove(tender);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateTender(Tenders tender)
        {
            if (db != null)
            {
                //Delete that post
                db.tenders.Update(tender);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
