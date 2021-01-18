using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.DataAccess.Contracts.Settings;
using MiniBusCrm.Domain.Contracts.Exceptions;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Models.Requests;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            return Ok(response);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("create")]
        public async Task<IActionResult> Create(UserModel newUser)
        {
            try
            {
                var result = await _userService.CreateUser(newUser);
                if (result == 0) return BadRequest(new {messsage = "Can't create user"});
                return Ok();

            }
            catch (UniqueUsernameException exception)
            {
                return BadRequest(new {message = exception.Message});
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UserModel editedUser)
        {
            var result = await _userService.UpdateUser(editedUser);
            if (result == 0) return BadRequest(new { messsage = "Can't update user" });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result == null) return BadRequest(new {message = "User not found!"});
            return Ok(result);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (result == 0) return BadRequest("Can't delete user");
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            return Ok(new {roles = new List<string>(UserRoles.GetRoles())});
        }
    }
}