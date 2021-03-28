using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DBContext.Submits
{
    public interface GoodsRepo
    {
        Task<List<SviewMOdel>> GetGoods();

        Task<SviewMOdel> GetGood(int? SubmitId);

        Task<int> AddGood(SubmitGood submit);

        Task<int> DeleteGood(int? SubmitId);

        Task UpdateGood(SubmitGood submit);
    }
}
