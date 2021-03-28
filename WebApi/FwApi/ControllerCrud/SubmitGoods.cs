using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext;
using FwCore.DBContext.Submits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.ControllerCrud
{
    public class SubmitGoods : GoodsRepo
    {
        AppDataDbContext db;
        public SubmitGoods(AppDataDbContext _db)
        {
            db = _db;
        }

        public async Task<int> AddGood(SubmitGood submit)
        {
            if (db != null)
            {
                await db.submitGoods.AddAsync(submit);
                await db.SaveChangesAsync();

                return submit.SubmitId;
            }

            return 0;
        }

        public async Task<int> DeleteGood(int? SubmitId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var submit = await db.submitGoods.FirstOrDefaultAsync(x => x.SubmitId == SubmitId);

                if (submit != null)
                {
                    //Delete that post
                    db.submitGoods.Remove(submit);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<SviewMOdel> GetGood(int? SubmitId)
        {
            if (db != null)
            {
                return await (from t in db.submitGoods
                              join n in db.newGoods
                              on t.SubmitId equals n.SubmitId


                              select new SviewMOdel
                              {
                                  SubmitId = t.SubmitId,
                                  
                                  TenderRefNumber = t.TenderRefNumber,
                                  TenderTitle = t.TenderTitle,
                                  GoodsName = n.GoodsName,
                                  quentity = n.quentity,
                                  Price = n.Price,
                                  TotalPrice = t.TotalPrice,
                                  CompanyName=t.CompanyName
                                  

                              }).FirstOrDefaultAsync();
            }

            return null;

        }

        public async Task<List<SviewMOdel>> GetGoods()
        {
            if (db != null)
            {
                return await (from t in db.submitGoods
                              join n in db.newGoods
                              on t.SubmitId equals n.SubmitId


                              select new SviewMOdel
                              {
                                  SubmitId = t.SubmitId,
                                  TenderRefNumber = t.TenderRefNumber,
                                  TenderTitle = t.TenderTitle,
                                  GoodsName = n.GoodsName,
                                  quentity = n.quentity,
                                  Price = n.Price,
                                  TotalPrice = t.TotalPrice,
                                    CompanyName = t.CompanyName

                              }).ToListAsync();
            }

            return null;
        }

        public async Task UpdateGood(SubmitGood submit)
        {
            if (db != null)
            {
                //Delete that post
                db.submitGoods.Update(submit);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
