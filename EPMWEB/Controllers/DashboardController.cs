using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using EPM.WEB.Models;



namespace EPM.WEB.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            var dashboardData = GetDashboardDataFromApi();
            ViewBag.DashboardData = dashboardData;

            return View();
        }


        private async Task<DashboardData> GetDashboardDataFromApi()
        {
            // make api call

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.DashboardAPIPath);
                var response = await client.GetAsync(client.BaseAddress + "GetCountNoOfUsersOverallClients");

                if (response.IsSuccessStatusCode)
                {
                   
                    var dashboardData = await response.Content.ReadAsStringAsync();
                    ViewBag.DashboardData = dashboardData;

                    //   ViewBag.DashboardData = dashboardData.TotalUsersOverallClients;
                    // ViewBag.DashboardData = dashboardData.TotalClientsPerDate;
                    // ViewBag.DashboardData = dashboardData.TotalUsersPerLocation;
                    return ViewBag.DashboardData;
                }
                else
                {
                    // handle error
                    throw new Exception("Failed to retrieve dashboard data from API");
                }
            }
        }
               
    }
}