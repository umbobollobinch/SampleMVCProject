using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample001.Services;

namespace Sample001.Controllers
{
    //[Authorize]
    public class Pref : Controller
    {
        ICovidServices _covidServices;

        public Pref(ICovidServices covidServices)
        { // これをコンストラクタと呼ぶ
            _covidServices = covidServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> PrefPortal(string pref)
        public IActionResult PrefPortal(string pref)
        {
            //await _covidServices.SetDatabase(pref);
            var cityofPatients = _covidServices.GetDatabase(pref);
            ViewBag.Place = pref;
            // If you make 'Prefs' folder to match the name of PrefsController, you don't have to enter the path of the view;
            // This also means you can select any view out of the 'Prefs' folder: return View("../Prefs/Gunma") is also OK
            return View(cityofPatients);
        }
    }
}
