using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Interface;
using StudentTransferManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountBusiness accountBusiness;

        public HomeController(ILogger<HomeController> logger, IAccountBusiness accountBusiness)
        {
            _logger = logger;
            this.accountBusiness = accountBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await this.accountBusiness.Register(request);
            return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
