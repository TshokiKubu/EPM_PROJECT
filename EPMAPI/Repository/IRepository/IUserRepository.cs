using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EPM.API.Data;
using EPM.API.Models;
using EPM.API.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EPM.API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string email);
        Users Authenticate(string email, string password);
        Users Register(string email, string password, string username);       
    }
}

