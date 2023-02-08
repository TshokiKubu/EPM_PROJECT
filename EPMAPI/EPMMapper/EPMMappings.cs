using AutoMapper;
using EPM.API.Data;
using EPM.API.Models;
using EPM.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EPM.API.EPMMapper
{  
   public class EPMMappings : Profile
    {
        public EPMMappings()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Users, UserDto>().ReverseMap();
        }
    }
}