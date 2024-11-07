using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample001.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger) {
            _logger = logger;
        }

        [Route("/Error")]
        [Route("/Error/Error")]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? code)
        {
            switch (code) 
            {
                case 404:
                    _logger.LogWarning("PAGE NOT FOUND; CODE:" + (code));
                    break;
                default:
                    _logger.LogError("INTERNAL SERVER ERROR HAS OCCURED; CODE:" + (code ?? 500));
                    break;
            }
            return View(new ErrorViewModel {statusCode = code ?? 500, requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            //return Problem();
        }
    }
}
