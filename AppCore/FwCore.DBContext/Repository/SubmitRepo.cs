using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DBContext.Repository
{
  public  interface SubmitRepo
    {
        Task <List<SubmissionViewModel>> SubmittedTenders();

        Task<SubmissionViewModel> SubmittedTender(int? sId);

        Task<int> SubmitTender(Submission submission);

        Task<int> DeleteSubmittedTender(int? sId);

        Task UpdateSubmittedTender(Submission submission);
    }
}
