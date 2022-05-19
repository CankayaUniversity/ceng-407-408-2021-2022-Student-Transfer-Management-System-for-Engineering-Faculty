using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Interface;
using StudentTransferManagementSystem.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudentTransferManagementSystem.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorBusiness instructorBusiness;

        public InstructorController(IInstructorBusiness instructorBusiness)
        {
            this.instructorBusiness = instructorBusiness;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Instructor()
        {

            return View();
        }


    }
}
