using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FwCore.DBContext.Model;

namespace FwCore.DBContext.Repository
{
  public  interface InterfaceRepo
    {
        Task<List<ProjectShowViewModel>> ShowTenders();

        Task<ProjectShowViewModel> ShowTender(int? tenderID);
    }
}
