using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using FwCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FwApi.AppIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public AppUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("users")]
        //[Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            var user = _userManager.Users.ToList();

            return Ok(user);

        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> Get(string Id)
        {
            var model = await _userManager.FindByIdAsync(Id);
            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber };
                var user = _userManager.CreateAsync(newUser, model.Password).Result;
                if (user.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "user");
                }

                return Ok();
            }


            return NoContent();
        }

        [HttpPut("{id}")]
        [Route("update")]
        public async Task<IActionResult> Edit(UserViewModel updateUser, string id)
        {
            var model = await _userManager.FindByIdAsync(updateUser.Id);
            if (model != null)
            {


                if (User.IsInRole("admin") == true)
                {
                    await _userManager.AddToRolesAsync(model, updateUser.Roles);

                }
                else
                {
                    model.UserName = updateUser.UserName;
                    model.PhoneNumber = updateUser.PhoneNumber;
                    model.Email = updateUser.Email;
                    model.FirstName = updateUser.FirstName;
                    model.LastName = updateUser.LastName;
                    model.PasswordHash = updateUser.Password;
                }


                var Update = await _userManager.UpdateAsync(model);

                return Ok(updateUser);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Route("delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id != null)
            {
                var user = await _userManager.FindByIdAsync(Id);
                var delete = await _userManager.DeleteAsync(user);
                return Ok();
            }
            return Ok();
        }

    }//c
}//ns