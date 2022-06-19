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

        public AdminController(IAdminBusiness adminBusiness)
        {
            this.adminBusiness = adminBusiness;
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
            var result = await adminBusiness.GetDepartments();

            return View(result);
        }

        public async Task<ActionResult> SaveUserRole(UserRoleRequest request)
        {
            var result = await adminBusiness.SaveUserRole(request);

            return NoContent();
        }

        public async Task<ActionResult> RoleList()
        {
            var result = await adminBusiness.GetRoles();
            return View(result);
        }
    }
}
