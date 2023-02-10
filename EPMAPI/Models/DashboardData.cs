using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.API.Models
{
    public class DashboardData
    {
        public int TotalUsersPerLocation { get; set; }
        public int TotalUsersOverallClients { get; set; }
        public int TotalClientsPerDate { get; set; }
    }
}
