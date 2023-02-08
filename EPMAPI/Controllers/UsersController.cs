using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EPM.API.Data;
//using EPM.API.Data.Dtos;
using EPM.API.Models;
using EPM.API.Models.Dtos;
using EPM.API.Repository.IRepository;
using AutoMapper;

namespace EPM.API.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/Users")]
   // [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;

        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userRepo.Authenticate(model.Email, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthenticationModel model)
        {
            bool ifUserNameUnique = _userRepo.IsUniqueUser(model.Email);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "Email already exists" });
            }
            var user = _userRepo.Register(model.Email, model.Password, model.Username);

            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }

            return Ok();
        }

       
    }
}