using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext.Repository;
using FwCore.DBContext.ViewModel;

namespace FwApi.ControllerCrud
{
    public class ProfileCrud : ProfileRepo
    {
        AppDataDbContext db;

        public ProfileCrud(AppDataDbContext _db)
        {
            db = _db;
        }
        public async Task<int> AddProfile(Profile profile)
        {
            if (db != null)
            {
                await db.Profiles.AddAsync(profile);
                await db.SaveChangesAsync();

                return profile.Id;
            }

            return 0;
        }

        public async Task<int> DeleteProfile(int? ProfileId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var profile = await db.Profiles.FirstOrDefaultAsync(x => x.Id == ProfileId);

                if (profile != null)
                {
                    //Delete that post
                    db.Profiles.Remove(profile);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<ProfileviewModel> GetProfile(int? ProfileId)
        {
            if (db != null)
            {
                return await (from t in db.Profiles

                              select new ProfileviewModel
                              {
                                  Id=  t.Id,
                                  CompanyName = t.CompanyName,
                                  Email=t.Email,
                                  CompanyCategory = t.CompanyCategory,
                                  CompanyAddress = t.CompanyAddress,
                                  Phone = t.Phone,
                                  TradeLicenseNo = t.TradeLicenseNo,
                                  Description = t.Description,
                                  ProductSpecification = t.ProductSpecification

                              }).FirstOrDefaultAsync();
            }

            return null;
        }


        public async Task<List<ProfileviewModel>> GetProfiles()
        {

            if (db != null)
            {
                return await (from t in db.Profiles

                              select new ProfileviewModel
                              {
                                  Id = t.Id,
                                  CompanyName = t.CompanyName,
                                  Email = t.Email,
                                  CompanyCategory = t.CompanyCategory,
                                  CompanyAddress = t.CompanyAddress,
                                  Phone = t.Phone,
                                  TradeLicenseNo = t.TradeLicenseNo,
                                  Description = t.Description,
                                  ProductSpecification = t.ProductSpecification

                              }).ToListAsync();
            }

            return null;
        }




        public async Task UpdateProfile(Profile profile)
        {
            if (db != null)
            {
                //Delete that post
                db.Profiles.Update(profile);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

    }
}
