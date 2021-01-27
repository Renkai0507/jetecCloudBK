using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BkServer.Models;

namespace BkServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AccountController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index","Home");
        }
         public IActionResult Login()
        {
            return RedirectToAction("Index","Home");
        }

       
    }
}
