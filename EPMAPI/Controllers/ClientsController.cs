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
    //[Authorize]
    [Route("api/v{version:apiVersion}/Clients")]
   // [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientsRepo;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientsRepo, IMapper mapper)
        {
            _clientsRepo = clientsRepo;
            _mapper = mapper;

        }

        [HttpGet("{id:int}", Name = "GetClient")]
        [ProducesResponseType(200, Type = typeof(ClientDto))]
        [ProducesResponseType(404)]
        //[Authorize]//(Roles = "Admin")]
        [AllowAnonymous]
        [ProducesDefaultResponseType]
        public IActionResult GetClient(int id)
        {
            var obj = _clientsRepo.GetClient(id);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<ClientDto>(obj);

            return Ok(objDto);
        }

        [HttpGet(Name = "GetClients")]
        [ProducesResponseType(200, Type = typeof(List<ClientDto>))]
        [ProducesResponseType(404)]
       // [Authorize]
        [AllowAnonymous]
        [ProducesDefaultResponseType]
        public IActionResult GetClients()
        {
            var objList = _clientsRepo.GetClients();
            var objDto = new List<ClientDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ClientDto>(obj));
            }
            return Ok(objDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public IActionResult CreateClientContact([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_clientsRepo.ClientExists(clientDto.ClientName))
            {
                ModelState.AddModelError("", "Client Name Exists!");
                return StatusCode(404, ModelState);
            }
            var contactObj = _mapper.Map<Client>(clientDto);
            if (!_clientsRepo.CreateClient(contactObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {contactObj.ClientName}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetContact", new { ID = contactObj.ID }, contactObj);
        }


    }
}
