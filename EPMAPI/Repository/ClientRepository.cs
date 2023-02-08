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

namespace EPM.API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }      

        public bool CreateClient(Client client)
        {
            _db.clients.Add(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _db.clients.Remove(client);
            return Save();
        }

        public bool UpdateClient(Client client)
        {
            _db.clients.Update(client);
            return Save();
        }

        public Client GetClient(int id)
        {
            return _db.clients.FirstOrDefault(a => a.ID == id);
        }

        public ICollection<Client> GetClients()
        {
            return _db.clients.OrderBy(a => a.ClientName).ToList();
        }  

        public bool ClientExists(string name)
        {
            bool value = _db.clients.Any(a => a.ClientName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


        public int GetCountNoOfUsersPerLocation(string loc)
        {
            
            return _db.clients
                    .Where(c => c.Location == loc)
                    .Select(x => x.NumberOfUsers)
                    .Sum();
        }

        public int GetCountNoOfUsersOverallClients()
        {
            return _db.clients                  
                    .Select(x => x.NumberOfUsers)
                    .Sum();
        }

        public int GetCountNoOfClientsPerDate(DateTime date)
        {           
            return _db.clients
                     .Where(c => c.CreatedOn.Date == date.Date)
                     .Select(x => x.NumberOfUsers)
                     .Sum();                     

        }
    }
}
