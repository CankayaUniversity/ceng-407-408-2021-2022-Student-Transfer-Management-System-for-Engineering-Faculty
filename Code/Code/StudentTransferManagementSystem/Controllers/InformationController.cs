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

        public InformationController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var studentList = await studentBusiness.ListAllStudent();
            return View(studentList);
        }
    }
}
