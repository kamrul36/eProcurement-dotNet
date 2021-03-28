using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext.Submits;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitGoodsController : ControllerBase
    {

        GoodsRepo repository;

        public SubmitGoodsController(GoodsRepo _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("GetGoods")]
        public async Task<IActionResult> GetGoods()
        {
            try
            {
                var submit = await repository.GetGoods();
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
        [Route("GetGood")]
        public async Task<IActionResult> GetGood(int? SubmitId)
        {
            if (SubmitId == null)
            {
                return BadRequest();
            }

            try
            {
                var submit = await repository.GetGood(SubmitId);

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
        [Route("AddGood")]
        public async Task<IActionResult> AddGood([FromBody]SubmitGood model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var submitid = await repository.AddGood(model);
                    if (submitid > 0)
                    {
                        return Ok(submitid);
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
        [Route("DeleteGood")]
        public async Task<IActionResult> DeleteGood(int? SubmitId)
        {
            int result = 0;

            if (SubmitId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DeleteGood(SubmitId);
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
        [Route("UpdateGood")]
        public async Task<IActionResult> UpdateGood([FromBody]SubmitGood model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateGood(model);

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
