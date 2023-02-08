using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.API.Models;

namespace EPM.API.Repository.IRepository
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        bool ClientExists(string name);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);
        bool Save();
         
        int GetCountNoOfUsersPerLocation(string loc);
        int GetCountNoOfUsersOverallClients();// int num);
        int GetCountNoOfClientsPerDate(DateTime date);
    }
}

