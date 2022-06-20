using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Classes;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
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
        private readonly INotyfService notyf;
        private readonly IAccountBusiness accountBusiness;

        public StudentController(IStudentBusiness studentBusiness, INotyfService notyf,IAccountBusiness accountBusiness)
        {
            this.studentBusiness = studentBusiness;
            this.notyf = notyf;
            this.accountBusiness = accountBusiness;
        }
        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> StudentDetail(int Id)
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }

        [HttpPost]
        public async Task<IActionResult> StudentCourseListDetail(int Id)
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }

        public async Task<ActionResult> DownloadPDF(int Id)
        {
            var file = await this.studentBusiness.GetFileDetail(Id);
            byte[] byteArray = Convert.FromBase64String(file.Content);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Octet, file.FileName);
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudentCourse(StudentCourseRequest request)
        {
            var currentUser = HttpContext.Session.GetString("name");

            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            request.UserName = currentUser;
            var result = await studentBusiness.SaveStudentCourse(request);

            return View("StudentDetail", result);
        }

        public async Task<ActionResult> CourseList()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var result = await studentBusiness.GetCourses(emailAddress);
            return View(result);
        }
        public async Task<ActionResult> UpdateCourseInstructor()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);
            var result = await studentBusiness.GetCourseViewData(emailAddress);
            return View(result);
        }

        public async Task<ActionResult> SaveCourseUser(CourseUserRequest request)
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var saveResult = await studentBusiness.SaveCourseUser(request);

            return NoContent();
        }

        public async Task<IActionResult> DepartmentHead(int Id)
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }

        public async Task<ActionResult> ApproveDepartmentHead()
        {
            var emailAddress = HttpContext.Session.GetString("email");

            await this.GetSession(emailAddress);

            var result = await studentBusiness.GetCourseApproveDepartmentHead();

            return View(result);
        }
    }
}
