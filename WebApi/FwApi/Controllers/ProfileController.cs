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
    public class ProfileController : ControllerBase
    {

        ProfileRepo repository;

        public ProfileController(ProfileRepo _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("GetProfiles")]
        public async Task<IActionResult> GetProfiles()
        {
            try
            {
                var profiles = await repository.GetProfiles();
                if (profiles == null)
                {
                    return NotFound();
                }

                return Ok(profiles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProfile")]
        public async Task<IActionResult> GetProfile(int? ProfileId)
        {
            if (ProfileId == null)
            {
                return BadRequest();
            }

            try
            {
                var profile = await repository.GetProfile(ProfileId);

                if (profile == null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddProfile")]
        public async Task<IActionResult> AddProfile([FromBody] Profile model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ProfileId = await repository.AddProfile(model);
                    if (ProfileId > 0)
                    {
                        return Ok(ProfileId);
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
        [Route("DeleteProfile")]
        public async Task<IActionResult> DeleteProfile(int? ProfileId)
        {
            int result = 0;

            if (ProfileId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DeleteProfile(ProfileId);
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
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody]Profile model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateProfile(model);

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
