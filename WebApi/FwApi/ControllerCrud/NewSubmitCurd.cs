using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using FwCore.DBContext.Repository;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.ControllerCrud
{
    public class NewSubmitCurd : NewSubmitRepo
    {
        AppDataDbContext db;

        public NewSubmitCurd(AppDataDbContext _db)
        {
            db = _db;
        }

        public async Task<int> AddSubmit(Submit submit)
        {
            if (db != null)
            {
                await db.submits.AddAsync(submit);
                await db.SaveChangesAsync();

                return submit.SubmitId;
            }

            return 0;
        }

        public async Task<int> DeleteSubmit(int? SubmitId)
        {

            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var submit = await db.submits.FirstOrDefaultAsync(x => x.SubmitId == SubmitId);

                if (submit != null)
                {
                    //Delete that post
                    db.submits.Remove(submit);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<SubmitViewModel> SubmittedProject(int? SubmitId)
        {
            if (db != null)
            {
                return await (from s in db.submits
                              join t in db.tenders
                              on s.TenderID equals t.TenderID
                              //join g in db.goods
                              // on s.SubmitId equals g.SubmitId
                              join p in db.ProductLists
                              on s.ProductId equals p.ProductId
                            


                              select new SubmitViewModel
                              {
                                  SubmitId= s.SubmitId,
                                  TenderRefNumber=t.TenderRefNumber,
                                  TenderTitle=t.TenderTitle,
                                  //GoodsName = g.GoodsName,
                                  //quentity = g.quentity,
                                  //Price =  g.Price,
                                  TotalPrice=s.TotalPrice


                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<SubmitViewModel>> SubmittedProjects()
        {
            if (db != null)
            {
                return await(from s in db.submits
                             join t in db.tenders
                             on s.TenderID equals t.TenderID
                             //join g in db.goods
                             //on s.SubmitId equals g.SubmitId
                             join p in db.ProductLists
                             on s.ProductId equals p.ProductId




                             select new SubmitViewModel
                             {
                                 SubmitId = s.SubmitId,
                                 TenderRefNumber = t.TenderRefNumber,
                                 TenderTitle = t.TenderTitle,
                                 //GoodsName = g.GoodsName,
                                 //quentity = g.quentity,
                                 //Price = g.Price,
                                 TotalPrice = s.TotalPrice

                             }).ToListAsync();
            }

            return null;
        }

        public async Task UpdateSubmit(Submit submit)
        {
            if (db != null)
            {
                //Delete that post
                db.submits.Update(submit);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
