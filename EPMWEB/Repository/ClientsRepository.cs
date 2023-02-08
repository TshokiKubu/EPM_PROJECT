
using EPM.WEB.Models;
using EPM.WEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPM.WEB.Repository
{
    public class ClientsRepository : Repository<Client>, IClientsRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public ClientsRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
       
    }
}

