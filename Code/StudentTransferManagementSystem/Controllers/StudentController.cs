using Microsoft.AspNetCore.Mvc;
using StudentTransferManagementSystem.Classes;
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
        public async Task<IActionResult> StudentListPage()
        {
            var studentList = await studentBusiness.ListAllStudent();
            return View(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> Instructor(int Id)
        {
            var selectedStudent = await studentBusiness.SelectedStudent(Id);
            return View(selectedStudent);
        }


        //TODO : 1 method 
        // id parametresi alıcak
        //business'a gidicek ve seçtiğimiz öğrencinin id si ile veri tabanından ilgili öğrenciyi çekicek
    }
}
