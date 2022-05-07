using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBusiness studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
