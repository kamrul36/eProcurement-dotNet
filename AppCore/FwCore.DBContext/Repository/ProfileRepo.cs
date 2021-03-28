using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FwCore.DBContext.Model;
using FwCore.DBContext.ViewModel;


namespace FwCore.DBContext.Repository
{
   public  interface ProfileRepo
    {
        Task<List<ProfileviewModel>> GetProfiles();

        Task<ProfileviewModel> GetProfile(int? ProfileId);

        Task<int> AddProfile(Profile profile);

        Task<int> DeleteProfile(int? ProfileId);

        Task UpdateProfile(Profile profile);
    }
}
