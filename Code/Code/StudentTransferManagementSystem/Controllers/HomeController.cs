using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Interface;
using StudentTransferManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountBusiness accountBusiness;
        private readonly IStudentBusiness studentBusiness;
        private readonly IAdminBusiness adminBusiness;
        private readonly INotyfService _notyf;
        public HomeController(ILogger<HomeController> logger,
            IAccountBusiness accountBusiness,
            INotyfService notyf,
            IStudentBusiness studentBusiness,
            IAdminBusiness adminBusiness)
        {
            _logger = logger;
            this.accountBusiness = accountBusiness;
            this._notyf = notyf;
            this.studentBusiness = studentBusiness;
            this.adminBusiness = adminBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await this.adminBusiness.GetDepartments();
            return View(departments);
        }

        public async Task<IActionResult> SaveStudent(RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.University))
            {
                _notyf.Warning("Please Enter University");
                return RedirectToAction("Index");
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                _notyf.Warning("Please Enter Name");
                return RedirectToAction("Index");

            }

            if (string.IsNullOrEmpty(request.Surname))
            {
                _notyf.Warning("Please Enter Surname");
                return RedirectToAction("Index");

            }

            if (string.IsNullOrEmpty(request.Ssn))
            {
                _notyf.Warning("Please Enter Ssn");
                return RedirectToAction("Index");

            }

            if (string.IsNullOrEmpty(request.Email))
            {
                _notyf.Warning("Please Enter Email");
                return RedirectToAction("Index");

            }

            if (request.File == null)
            {
                _notyf.Warning("Please Upload Transcript");
                return RedirectToAction("Index");

            }
            if (request.File.Count == 0 || request.File == null)
            {
                _notyf.Warning("Please Upload Transcript");

                return RedirectToAction("Index");

            }

            var result = await this.studentBusiness.SaveStudent(request);

            if (result)
            {
                _notyf.Success("Sucess");
                return RedirectToAction("Index");

            }

            if (!result)
            {
                _notyf.Error("Unexpected Error");
                return RedirectToAction("Index");
            }

            return NoContent();
        }

        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                _notyf.Error("Please Enter Email Address");
                return RedirectToAction("Index", "Home");
            }

            if (request.RegistrationNumber == 0)
            {
                _notyf.Error("Please Enter Registration Number");
                return RedirectToAction("Index", "Home");
            }

            if (request.Email == "administrator")
            {
                if (request.RegistrationNumber != 0007)
                {
                    _notyf.Error("Please Enter Correct Registration Number");
                    return RedirectToAction("Index", "Home");
                }

                HttpContext.Session.SetString("name", "administrator");
                HttpContext.Session.SetString("email", string.Empty);
                return RedirectToAction("Index", "Information");
            }
            else
            {
                var result = await this.accountBusiness.Login(request);

                if (!result.IsLoginSuccess)
                {
                    _notyf.Error("Email or Registration Number is Wrong!");
                    return RedirectToAction("Index", "Home");
                }

                HttpContext.Session.SetString("name", result.Name);
                HttpContext.Session.SetString("email", result.Email);

                ViewBag.name = result.Name;
            }

            return RedirectToAction("Index", "Information");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
