using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DBContext.Repository
{
  public  interface DemoTenderRepo
    {
        Task<List<TenderViewModel>> GetTenders();
    }
}
