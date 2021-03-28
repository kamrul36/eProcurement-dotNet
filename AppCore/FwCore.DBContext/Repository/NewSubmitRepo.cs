using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FwCore.DBContext.Model;
using FwCore.DBContext.ViewModel;

namespace FwCore.DBContext.Repository
{
   public interface NewSubmitRepo
    {
        Task<List<SubmitViewModel>> SubmittedProjects();

        Task<SubmitViewModel> SubmittedProject(int? SubmitId);

        Task<int> AddSubmit(Submit submit);

        Task<int> DeleteSubmit(int? SubmitId);

        Task UpdateSubmit(Submit submit);
    }
}
