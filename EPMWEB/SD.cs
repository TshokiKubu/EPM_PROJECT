using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.WEB
{
    public static class SD
    {
        public static string APIBaseUrl = "http://localhost:53593/";//44380/";
        public static string ClientAPIPath = APIBaseUrl + "api/v1/clients/";
        public static string AccountAPIPath = APIBaseUrl + "api/v1/Users/";
        public static string DashboardAPIPath = APIBaseUrl + "api/v1/dashboard/";
    }
}
