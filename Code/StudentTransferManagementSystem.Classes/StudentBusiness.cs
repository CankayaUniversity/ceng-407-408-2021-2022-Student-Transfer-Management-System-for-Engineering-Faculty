using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Enums;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentTransferManagementSystem.Classes
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IContainer container;

        public StudentBusiness(IContainer container)
        {
            this.container = container;
        }

        public async Task<List<StudentResponse>> ListAllStudent()
        {
            var userList = await this.container.Repository<User>().ListAll();

            var students = userList.Where(l => l.UserTypes == UserTypes.Student).ToList();


            //YONTEM 1
            var result = students.Select(x => new StudentResponse
            {
                Name = x.Name,
                Surname = x.Surname,
                Id = x.Id
            }).ToList();

            return result;


            //YONETIM 2
            //var listResult = new List<StudentResponse>();
            //foreach (var item in students)
            //{
            //    var studentResponse = new StudentResponse();
            //    studentResponse.Name = item.Name;
            //    studentResponse.Surname = item.Surname;
            //    studentResponse.Id = item.Id;
            //    listResult.Add(studentResponse);
            //}

            //return listResult;
        }
        public async Task<StudentResponse> SelectedStudent(int id)
        {
            var existStudent = await this.container.Repository<User>().GetById(id);

            var student = new StudentResponse();
            student.Id = existStudent.Id;
            student.Name = existStudent.Name;
            student.Surname = existStudent.Surname;
            student.SSN = existStudent.Ssn;
            student.Display = existStudent.Name + " - " + existStudent.Surname;

            return student;
        }
    }
}

