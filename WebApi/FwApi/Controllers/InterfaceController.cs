using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        InterfaceRepo repository;

        public InterfaceController(InterfaceRepo _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("InterfaceTenders")]
        public async Task<IActionResult> InterfaceTenders()
        {
            try
            {
                var tenders = await repository.ShowTenders();
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
        [Route("InterfaceTender")]
        public async Task<IActionResult> InterfceTender(int? tenderID)
        {
            if (tenderID == null)
            {
                return BadRequest();
            }

            try
            {
                var tender = await repository.ShowTender(tenderID);

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
