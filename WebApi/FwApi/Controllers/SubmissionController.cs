using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.Repository;
using FwCore.DBContext.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        SubmitRepo repository;

        public SubmissionController(SubmitCrud _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("GetSubmitTenders")]
        public async Task<IActionResult> SubmittedTenders()
        {
            try
            {
                var submit = await repository.SubmittedTenders();
                if (submit == null)
                {
                    return NotFound();
                }

                return Ok(submit);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetSubmitTender")]
        public async Task<IActionResult> SubmittedTender(int? sId)
        {
            if (sId == null)
            {
                return BadRequest();
            }

            try
            {
                var submit = await repository.SubmittedTender(sId);

                if (submit == null)
                {
                    return NotFound();
                }

                return Ok(submit);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddTender")]
        public async Task<IActionResult> SubmitTender([FromBody] Submission model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var sid = await repository.SubmitTender(model);
                    if (sid > 0)
                    {
                        return Ok(sid);
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
        [Route("DeleteSubmittedTender")]
        public async Task<IActionResult> DeleteSubmittedTender(int? sId)
        {
            int result = 0;

            if (sId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DeleteSubmittedTender(sId);
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
        [Route("UpdateSubmittedTender")]
        public async Task<IActionResult> UpdateSubmittedTender([FromBody]Submission model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateSubmittedTender(model);

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
