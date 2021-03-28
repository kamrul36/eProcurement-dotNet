using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.Repository;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using Microsoft.EntityFrameworkCore;



namespace FwApi.Controllers
{
    public class SubmitCrud : SubmitRepo
    {
        AppDataDbContext db;

        public SubmitCrud (AppDataDbContext _db)
        {
            db = _db;
        }

        public async Task<List<SubmissionViewModel>> SubmittedTenders()
        {
            if (db != null)
            {
                return await (from s in db.submissions

                              join t in db.tenders
                              on s.TenderID equals t.TenderID
                              join p in db.ProductLists
                              on s.ProductId equals p.ProductId
                             
                             

                              select new SubmissionViewModel
                              {
                              
                                  //productList= p.ProductName,
                                  quentity=p.Quentity,
                                  Price= s.Price

                              }).ToListAsync();
            }

            return null;
        }

        public async Task<SubmissionViewModel> SubmittedTender(int? sId)
        {
            if (db != null)
            {
                return await (from s in db.submissions

                              join t in db.tenders
                              on s.TenderID equals t.TenderID
                              join p in db.ProductLists
                              on s.ProductId equals p.ProductId



                              select new SubmissionViewModel
                              {
                              
                                  //productList = p.ProductName,
                                  quentity = p.Quentity,
                                  Price = s.Price

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> SubmitTender(Submission submission)
        {
            if (db != null)
            {
                await db.submissions.AddAsync(submission);
                await db.SaveChangesAsync();

                return submission.SId;
            }

            return 0;
        }

        public async Task<int> DeleteSubmittedTender(int? sId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var submit = await db.submissions.FirstOrDefaultAsync(x => x.SId == sId);

                if (submit != null)
                {
                    //Delete that post
                    db.submissions.Remove(submit);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateSubmittedTender(Submission submission)
        {
            if (db != null)
            {
                //Delete that post
                db.submissions.Update(submission);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
