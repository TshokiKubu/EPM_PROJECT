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
        //public IActionResult Index()
        //{
        //    return View();
       // }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.DashboardAPIPath);
                var response = await client.GetAsync(client.BaseAddress);// "dashboard");
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();

                // Store the data in a ViewBag object
                ViewBag.DashboardData = data;

                return Ok(data);
            }
          
        }

        //public async Task<IActionResult> Index(DateTime date, string loc, int num)
        //{
        //    // string loc = "";
        //  //  ViewBag.CountNoOfClientsPerDateAPI = _httpClientFactory.GetCountNoOfClientsPerDate(date);
        //  //  ViewBag.CountNoOfUsersOverallClientsAPI = _httpClientFactory.GetCountNoOfUsersOverallClients(num);
        //  //  ViewBag.CountNoOfUsersPerLocationAPI = _httpClientFactory.GetCountNoOfUsersPerLocation(loc);



        //    var client = _httpClientFactory.CreateClient(SD.DashboardAPIPath);     //("dashboardApi");
        //    var response = await client.GetAsync("CountNoOfUsers");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var dashboardData = JsonConvert.DeserializeObject<DashboardDataModel>(content);



        //      //  ViewBag.Date = date;
        //      //  ViewBag.Location = loc;
        //      //  ViewBag.OverallUsersClients = num;

        //        ViewBag.Dashboard = dashboardData;



        //        return View(dashboardData);
        //    }
        //    else
        //    {
        //        return View("Error");
        //    }

        //}
    }
}