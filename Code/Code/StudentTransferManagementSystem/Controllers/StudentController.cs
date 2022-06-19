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

        public StudentController(IStudentBusiness studentBusiness, INotyfService notyf)
        {
            this.studentBusiness = studentBusiness;
            this.notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> StudentListPage()
        {
            var studentList = await studentBusiness.ListAllStudent();
            return View(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> StudentDetail(int Id)
        {
            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }

        [HttpPost]
        public async Task<IActionResult> StudentCourseListDetail(int Id)
        {
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

            request.UserName = currentUser;
            var result = await studentBusiness.SaveStudentCourse(request);


            //var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View("StudentDetail", result);
        }

        public async Task<ActionResult> CourseList()
        {
            var result = await studentBusiness.GetCourses();
            return View(result);
        }
        public async Task<ActionResult> UpdateCourseInstructor()
        {
            var result = await studentBusiness.GetCourseViewData();
            return View(result);
        }

        public async Task<ActionResult> SaveCourseUser(CourseUserRequest request)
        {
            var saveResult = await studentBusiness.SaveCourseUser(request);

            return NoContent();
        }

        //public async Task<ActionResult> Admin()
        //{
        //    var result = await studentBusiness.GetRoles();
        //    return View(result);
        //}
        public async Task<IActionResult> DepartmentHead(int Id)
        {
            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }



        public async Task<ActionResult> ApproveDepartmentHead()
        {
            var result = await studentBusiness.GetCourseApproveDepartmentHead();

            return View(result);
        }




        //TODO : 1 method 
        // id parametresi alıcak
        //business'a gidicek ve seçtiğimiz öğrencinin id si ile veri tabanından ilgili öğrenciyi çekicek
    }
}
