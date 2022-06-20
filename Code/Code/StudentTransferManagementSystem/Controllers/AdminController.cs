using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBusiness adminBusiness;
        private readonly IAccountBusiness accountBusiness;

        public AdminController(IAdminBusiness adminBusiness, IAccountBusiness accountBusiness)
        {
            this.adminBusiness = adminBusiness;
            this.accountBusiness = accountBusiness;
        }

        //TODO
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Admin()
        {

            return View();
        }

        public async Task<ActionResult> DepartmentList()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var result = await adminBusiness.GetDepartments();

            return View(result);
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

                ViewBag.name = existUser.DisplayName;
                ViewBag.isAdmin = false;
                ViewBag.userType = existUser.UserType;
            }
        }

        public async Task<ActionResult> SaveUserRole(UserRoleRequest request)
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var result = await adminBusiness.SaveUserRole(request);

            return NoContent();
        }

        public async Task<ActionResult> RoleList()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var result = await adminBusiness.GetRoles();
            return View(result);
        }
    }
}
