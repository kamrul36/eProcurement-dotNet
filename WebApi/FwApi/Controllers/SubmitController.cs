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
    public class SubmitController : ControllerBase
    {

        NewSubmitRepo repository;

        public SubmitController(NewSubmitRepo _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("SubmittedProjects")]
        public async Task<IActionResult> SubmittedProjects()
        {
            try
            {
                var submit = await repository.SubmittedProjects();
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
        [Route("SubmittedProject")]
        public async Task<IActionResult> SubmittedProject(int? SubmitId)
        {
            if (SubmitId == null)
            {
                return BadRequest();
            }

            try
            {
                var submit = await repository.SubmittedProject(SubmitId);

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
        [Route("AddSubmit")]
        public async Task<IActionResult> AddSubmit([FromBody] Submit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var SubmitId = await repository.AddSubmit(model);
                    if (SubmitId > 0)
                    {
                        return Ok(SubmitId);
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
        [Route("DeleteSubmit")]
        public async Task<IActionResult> DeleteSubmit(int? SubmitId)
        {
            int result = 0;

            if (SubmitId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DeleteSubmit(SubmitId);
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
        [Route("UpdateSubmit")]
        public async Task<IActionResult> UpdateSubmit([FromBody]Submit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateSubmit(model);

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
