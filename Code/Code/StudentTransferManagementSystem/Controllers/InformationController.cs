using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Controllers
{
    public class InformationController : Controller
    {
        private readonly IStudentBusiness studentBusiness;
        private readonly IAccountBusiness accountBusiness;

        public InformationController(IStudentBusiness studentBusiness, IAccountBusiness accountBusiness)
        {
            this.studentBusiness = studentBusiness;
            this.accountBusiness = accountBusiness;
        }

        private async Task GetSession(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.name = "administrator";
                ViewBag.isAdmin = true;
            }
            else
            {
                var existUser = await this.accountBusiness.GetUserDetail(email);
                var name = HttpContext.Session.GetString("name");

                ViewBag.name = existUser.DisplayName;
                ViewBag.isAdmin = false;
                ViewBag.userType = existUser.UserType;
            }
        }

        public async Task<IActionResult> Index()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);
            var studentList = await studentBusiness.ListAllStudent(emailAddress);
            return View(studentList);
        }
    }
}
