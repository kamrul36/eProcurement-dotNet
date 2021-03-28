using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
  public interface IRepository
    {

        Task<List<TenderViewModel>> GetTenders();

        Task<TenderViewModel> GetTender(int? tenderID);

        Task<int> AddTender(Tenders tender);

        Task<int> DeleteTender(int? Tenderid);

        Task UpdateTender(Tenders tender);
    }
}
