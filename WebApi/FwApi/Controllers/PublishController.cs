using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        PublishRepo repository;

        public PublishController(PublishRepo _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("PublishedTenders")]
        public async Task<IActionResult> PublishTenders()
        {
            try
            {
                var tenders = await repository.PublishTenders();
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
        [Route("PublishedTender")]
        public async Task<IActionResult> PublishTender(int? tenderID)
        {
            if (tenderID == null)
            {
                return BadRequest();
            }

            try
            {
                var tender = await repository.PublishTender(tenderID);

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
    }
}
