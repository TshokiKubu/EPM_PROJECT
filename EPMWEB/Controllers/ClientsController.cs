using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPM.WEB.Models;
using EPM.WEB.Models.ViewModel;
using EPM.WEB.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace EPM.WEB.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientsRepository _clRepo;
        
        public ClientsController(IClientsRepository clRepo)
        {
            _clRepo = clRepo;          
        }

        public IActionResult Index()
        {
            return View(new Client() { });
        }

        public async Task<IActionResult> GetAllClients()
        {
            return Json(new { data = await _clRepo.GetAllAsync(SD.ClientAPIPath, HttpContext.Session.GetString("JWToken")) });
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upsert(int? id)
        {
            Client obj = new Client();

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come here for update
            obj = await _clRepo.GetAsync(SD.ClientAPIPath, id.GetValueOrDefault(), HttpContext.Session.GetString("JWToken"));
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Client obj)
        {
            if (ModelState.IsValid)
            {
             //   var files = HttpContext.Request.Form.Files;
                
                if (obj.ID == 0)
                {
                    await _clRepo.CreateAsync(SD.ClientAPIPath, obj, HttpContext.Session.GetString("JWToken"));
                }
                else
                {
                    await _clRepo.UpdateAsync(SD.ClientAPIPath + obj.ID, obj, HttpContext.Session.GetString("JWToken"));
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obj);
            }
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _clRepo.DeleteAsync(SD.ClientAPIPath, id, HttpContext.Session.GetString("JWToken"));
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete Not Successful" });
        }
    }
}