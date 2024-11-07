using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Sample001.DBContexts;
using Sample001.Models;
using Sample001.Services;
using Microsoft.Extensions.Logging;

namespace Sample001.Controllers
{
    public class HomeController : Controller
    {
        ICovidServices _covidServices;
        // ILogger<HomeController> _logger;

        private string tName = "Default";

        public HomeController(ICovidServices covidServices)
        { // これをコンストラクタと呼ぶ
            _covidServices = covidServices;
        }

        //[Authorize]
        public async Task<IActionResult> SetUp() {
            await _covidServices.SetDatabase();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var positivePatients = _covidServices.GetDatabase(tName);
            ViewBag.Place = tName;

            return View(positivePatients);
        }
    }
}
