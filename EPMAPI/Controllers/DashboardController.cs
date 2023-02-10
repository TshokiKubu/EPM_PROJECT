using Microsoft.AspNetCore.Mvc;
using EPM.API.Data;
using EPM.API.Models;
using EPM.API.Models.Dtos;
using EPM.API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace EPMAPI.Controllers
{
   
    [Route("api/v{version:apiVersion}/dashboard")]  
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IClientRepository _clientsRepo;
        private readonly IMapper _mapper;

        public DashboardController(IClientRepository clientsRepo, IMapper mapper)
        {
            _clientsRepo = clientsRepo;
            _mapper = mapper;
        }

        [HttpGet("{loc:alpha}",Name = "CountNoOfUsers")]      
        [AllowAnonymous]     
        public IActionResult CountNoOfUsers(string loc)
        {
            var obj = _clientsRepo.GetCountNoOfUsersPerLocation(loc);
            if (obj == 0)
            {
                return NotFound();
            }           
            return Ok(obj);
        }

        [HttpGet("GetCountNoOfUsersOverallClients")]
        [AllowAnonymous]
        public IActionResult GetCountNoOfUsersOverallClients()
        {
            var objDto = _clientsRepo.GetCountNoOfUsersOverallClients();
            return Ok(objDto);
        }

        [HttpGet("{date:DateTime}", Name = "GetCountNoOfClientsPerDate")]
        [AllowAnonymous]      
        public IActionResult  GetCountNoOfClientsPerDate(DateTime date)
        {
            int objDto = _clientsRepo.GetCountNoOfClientsPerDate(date);
            return Ok(objDto);
        }
    }
}
