using System;
using System.Collections.Generic;
using System.Text;
using FwCore.DBContext.ViewModel;
using FwCore.DBContext.Model;
using System.Threading.Tasks;

namespace FwCore.DBContext.Repository
{
  public  interface PublishRepo
    {
        Task<List<PublishTenderViewModel>> PublishTenders();

        Task<PublishTenderViewModel> PublishTender(int? sId);

    }

}
