using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using FwCore.DBContext.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {

        IRepository repository;

        public TenderController(IRepository _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("Getenders")]
        public async Task<IActionResult> GetTenders()
        {
            try
            {
                var tenders = await repository.GetTenders();
                if (tenders == null)
                {
                    return NotFound();
                }

                return Ok(tenders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetTender")]
        public async Task<IActionResult> GetTender(int? tenderID)
        {
            if (tenderID == null)
            {
                return BadRequest();
            }

            try
            {
                var tender = await repository.GetTender(tenderID);

                if (tender == null)
                {
                    return NotFound();
                }

                return Ok(tender);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Addtender")]
        public async Task<IActionResult> AddTender([FromBody]Tenders model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var TenderID = await repository.AddTender(model);
                    if (TenderID > 0)
                    {
                        return Ok(TenderID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Deletetender")]
        public async Task<IActionResult> DeleteTender(int? Tenderid)
        {
            int result = 0;

            if (Tenderid == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DeleteTender(Tenderid);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Updatetender")]
        public async Task<IActionResult> UpdateTender([FromBody]Tenders model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateTender(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
