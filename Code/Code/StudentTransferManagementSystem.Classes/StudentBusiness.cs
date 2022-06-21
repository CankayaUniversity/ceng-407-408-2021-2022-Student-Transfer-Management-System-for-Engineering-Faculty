using Microsoft.AspNetCore.Http;
using StudentTransferManagementSystem.Classes.Helper;
using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Enums;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.IO;
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
        private async Task<User> GetUserByEmail(string email)
        {
            var userList = await this.container.Repository<User>().ListAll();

            var existUser = userList.Where(l => l.Email == email).FirstOrDefault();
            return existUser;
        }
        public async Task<List<StudentResponse>> ListAllStudent(string emailAddress)
        {
            List<Student> students = new List<Student>();
            students = await this.container.Repository<Student>().ListAll();

            if (!string.IsNullOrEmpty(emailAddress))
            {
                var user = await this.GetUserByEmail(emailAddress);
                students = students.Where(l => l.DepartmentId == user.DepartmentId).ToList();
            }

            //var students = userList.Where(l => l.UserTypes == UserTypes.Student).ToList();


            //YONTEM 1
            var result = students.Select(x => new StudentResponse
            {
                Name = x.Name,
                Surname = x.Surname,
                DisplayName = x.Name + " " + x.Surname,
                Id = x.Id,
                Status = EnumHelper.GetDescription(x.StudentStatus)
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

            var existStudent = await this.container.Repository<Student>().GetById(id);

            var student = new StudentResponse();
            student.Id = existStudent.Id; //1
            student.Name = existStudent.Name; //Özlem
            student.Surname = existStudent.Surname;
            student.Email = existStudent.Email;
            student.SSN = existStudent.Ssn;
            student.University = existStudent.University;
            student.DisplayName = existStudent.Name + " " + existStudent.Surname;

            var files = await this.container.Repository<CustomFile>().GetByWithExpressionList(l => l.StudentId == id);



            var selectedFiles = files.Select(l => new FileResponse
            {
                Content = l.FileContent,
                FileName = l.FileName,
                FileContenType = l.FileType,
                Id = l.Id
            });

            foreach (var item in selectedFiles.ToList())
            {
                student.FileResponses.Add(item);
            }

            var dbcourses = await this.container.Repository<StudentCourse>().ListAll();

            var courses = dbcourses.Where(l => l.StudentId == id).ToList();

            foreach (var item in courses)
            {
                var courseResponse = new StudentCourseResponse();
                courseResponse.Id = item.Id;
                courseResponse.StudentId = item.StudentId;
                courseResponse.EquivalentCourseCode = item.EquivalentCourseCode;
                courseResponse.EquivalentCourseCredit = item.EquivalentCourseCredit;
                courseResponse.EquivalentCourseGrade = item.EquivalentCourseGrade;
                courseResponse.Status = item.Status;
                courseResponse.TakenCourseCode = item.TakenCourseCode;
                courseResponse.TakenCourseGrade = item.TakenCourseGrade;
                courseResponse.TakenCouseCredit = item.TakenCouseCredit;
                courseResponse.Username = item.Username;

                student.StudentCourseResponses.Add(courseResponse);
            }

            return student;
        }
        public async Task<bool> SaveStudent(RegisterRequest request)
        {
            try
            {
                var studentUser = new Student
                {
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,
                    Email = request.Email,
                    ModificationBy = "",
                    Name = request.Name,
                    Surname = request.Surname,
                    University = request.University,
                    Ssn = request.Ssn,
                    DepartmentId = request.DepartmentId
                };

                await this.container.Repository<Student>().Add(studentUser);

                foreach (var item in request.File)
                {
                    var customFile = new CustomFile();
                    customFile.FileName = item.FileName;
                    customFile.FileType = item.ContentType;
                    customFile.StudentId = studentUser.Id;
                    customFile.CreatedBy = "System";
                    customFile.CreatedDate = DateTime.Now;
                    customFile.ModificationBy = "";

                    using (var ms = new MemoryStream())
                    {
                        item.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        customFile.FileContent = s;
                    }

                    await this.container.Repository<CustomFile>().Add(customFile);
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
        public async Task<FileResponse> GetFileDetail(int Id)
        {
            var file = await this.container.Repository<CustomFile>().GetById(Id);

            var response = new FileResponse();
            response.FileName = file.FileName;
            response.Content = file.FileContent;
            response.FileContenType = file.FileType;
            response.Id = file.Id;
            return response;
        }
        public async Task<StudentResponse> SaveStudentCourse(StudentCourseRequest request)
        {
            var newCourse = new StudentCourse
            {
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                EquivalentCourseCode = request.EquivalentCourseCode,
                EquivalentCourseCredit = request.EquivalentCourseCredit,
                EquivalentCourseGrade = request.EquivalentCourseGrade,
                Status = request.Status,
                TakenCourseCode = request.TakenCourseCode,
                TakenCourseGrade = request.TakenCourseGrade,
                TakenCouseCredit = request.TakenCouseCredit,
                StudentId = request.StudentId,
                Username = request.UserName
            };

            await this.container.Repository<StudentCourse>().Add(newCourse);

            var student = await this.SelectedStudent(request.StudentId);

            return student;
        }
        public async Task<List<CourseResponse>> GetCourses(string email)
        {
            var list = await this.container.Repository<Course>().ListAll();

            if (!string.IsNullOrEmpty(email))
            {
                var user = await this.GetUserByEmail(email);
                list = list.Where(l => l.DepartmentId == user.DepartmentId).ToList();
            }

            List<CourseResponse> result = new List<CourseResponse>();
            foreach (var item in list)
            {
                var courseResponse = new CourseResponse();
                courseResponse.CourseCode = item.CourseCode;
                courseResponse.CourseName = item.CourseName;
                courseResponse.Credit = item.Credit;
                courseResponse.CourseId = item.Id;
                courseResponse.Time = item.Time;
                courseResponse.Type = item.Type;
                courseResponse.AKTS = item.AKTS;
                var courseInstructorList = await this.container.Repository<CourseUser>().ListAll();

                var courseInstructor = courseInstructorList.Where(l => l.CourseId == item.Id).FirstOrDefault();

                if (courseInstructor != null)
                {
                    courseResponse.UserId = courseInstructor.UserId;

                    var user = await this.container.Repository<User>().GetById(courseResponse.UserId);
                    if (user != null)
                    {
                        courseResponse.UserDisplayName = user.Name + " " + user.Surname;
                    }
                }

                courseResponse.Status = EnumHelper.GetDescription(item.CourseInstructorStatus);

                result.Add(courseResponse);
            }


            return result;
        }
        public async Task<List<InstructorResponse>> ListAllInstructor(string email)
        {
            var instructors = await this.container.Repository<User>().ListAll();

            if (!string.IsNullOrEmpty(email))
            {
                var user = await this.GetUserByEmail(email);
                instructors = instructors.Where(l => l.DepartmentId == user.DepartmentId).ToList();
            }

            var result = instructors.Where(l => l.UserType == UserType.Instructor).Select(x => new InstructorResponse
            {
                Name = x.Name,
                Surname = x.Surname,
                DisplayName = x.Name + " " + x.Surname,
                UserId = x.Id
            }).ToList();

            return result;
        }
        public async Task<CourseInstructorResponse> GetCourseViewData(string email)
        {
            var courses = await this.GetCourses(email);

            var users = await this.ListAllInstructor(email);

            var response = new CourseInstructorResponse();

            response.CourseResponses = courses;

            response.InstructorResponses = users;

            return response;
        }
        public async Task<bool> SaveCourseUser(CourseUserRequest request)
        {
            if (request.CourseId > 0 && request.UserId > 0)
            {
                var list = await this.container.Repository<CourseUser>().ListAll();

                var existCourseUser = list.Where(l => l.CourseId == request.CourseId).FirstOrDefault();

                if (existCourseUser != null)
                {
                    existCourseUser.UserId = request.UserId;

                    var existCourse = await this.container.Repository<Course>().GetById(request.CourseId);

                    existCourse.CourseInstructorStatus = CourseInstructorEnum.WaitingDepartmentHead;

                    await this.container.Repository<CourseUser>().Save();
                }
                else
                {
                    var newCourseUser = new CourseUser
                    {
                        CreatedBy = "System",
                        CreatedDate = DateTime.Now,
                        CourseId = request.CourseId,
                        UserId = request.UserId
                    };

                    var existCourse = await this.container.Repository<Course>().GetById(request.CourseId);

                    existCourse.CourseInstructorStatus = CourseInstructorEnum.WaitingDepartmentHead;

                    await this.container.Repository<CourseUser>().Add(newCourseUser);
                }

            }

            return true;
        }
        public async Task<RoleResponse> AssignRole()
        {
            ////var roles = await this.GetRoles();

            ////var users = await this.ListAllInstructor();

            ////var response = new RoleResponse();

            ////response.RoleResponses = roles;

            ////response.InstructorResponses = users;

            ////return response;
            ///
            return null;
        }
        public async Task<List<CourseResponse>> GetCourseApproveDepartmentHead()
        {
            var courseList = await this.container.Repository<CourseUser>().ListAll();

            var result = new List<CourseResponse>();
            foreach (var item in courseList)
            {
                var response = new CourseResponse();
                var course = await this.container.Repository<Course>().GetById(item.CourseId);
                var user = await this.container.Repository<User>().GetById(item.UserId);

                if (course.CourseInstructorStatus == CourseInstructorEnum.WaitingDepartmentHead)
                {
                    response.CourseName = course.CourseName;
                    response.CourseCode = course.CourseCode;
                    response.CourseId = course.Id;
                    response.UserDisplayName = user.Name + " " + user.Surname;
                    response.UserId = user.Id;
                    result.Add(response);
                }
            }

            return result;
        }
        public async Task<bool> Approve(ApproveRejectRequest request)
        {
            var existCourse = await this.container.Repository<Course>().GetById(request.CourseId);

            var user = await this.container.Repository<User>().GetById(request.UserId);


            var allUserCourses = await this.container.Repository<CourseUser>().GetByWithExpressionList(l => l.UserId == request.UserId);

            bool isEmailSender = false;
            foreach (var item in allUserCourses)
            {
                var courses = await this.container.Repository<Course>().GetById(item.CourseId);

                if (courses.CourseInstructorStatus == CourseInstructorEnum.ApprovedDepartmentHead)
                {
                    isEmailSender = true;
                }
            }

            var existCourseUser = await this.container.Repository<CourseUser>().GetByWithExpression(l => l.CourseId == request.CourseId);

            if (existCourseUser != null)
            {
                existCourseUser.UserId = request.UserId;
            }

            if (!isEmailSender)
            {
                MailSender.Send(user.Email, "");
            }

            existCourse.CourseInstructorStatus = CourseInstructorEnum.ApprovedDepartmentHead;

            await this.container.Repository<CourseUser>().Save();

            return true;
        }
        public async Task<bool> Reject(ApproveRejectRequest request)
        {
            var existCourse = await this.container.Repository<Course>().GetById(request.CourseId);

            existCourse.CourseInstructorStatus = CourseInstructorEnum.Waiting;

            var existCourseUser = await this.container.Repository<CourseUser>().GetByWithExpression(l => l.CourseId == request.CourseId);

            if (existCourseUser != null)
            {
                existCourseUser.UserId = 0;
            }

            await this.container.Repository<CourseUser>().Save();

            return true;
        }

        public async Task<List<CourseResponse>> CourseList(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var existUser = await this.container.Repository<User>().GetByWithExpression(l => l.Email == email);

                var courseUserList = await this.container.Repository<CourseUser>().GetByWithExpressionList(l => l.UserId == existUser.Id);

                var courses = new List<Course>();

                foreach (var item in courseUserList)
                {
                    var course = await this.container.Repository<Course>().GetById(item.CourseId);

                    if (course.CourseInstructorStatus == CourseInstructorEnum.ApprovedDepartmentHead)
                    {
                        courses.Add(course);
                    }
                }

                List<CourseResponse> result = new List<CourseResponse>();
                foreach (var item in courses)
                {
                    var courseResponse = new CourseResponse();
                    courseResponse.CourseCode = item.CourseCode;
                    courseResponse.CourseName = item.CourseName;
                    courseResponse.Credit = item.Credit;
                    courseResponse.CourseId = item.Id;
                    courseResponse.Time = item.Time;
                    courseResponse.Type = item.Type;
                    courseResponse.AKTS = item.AKTS;
                    var courseInstructorList = await this.container.Repository<CourseUser>().ListAll();

                    var courseInstructor = courseInstructorList.Where(l => l.CourseId == item.Id).FirstOrDefault();

                    if (courseInstructor != null)
                    {
                        courseResponse.UserId = courseInstructor.UserId;

                        var user = await this.container.Repository<User>().GetById(courseResponse.UserId);
                        if (user != null)
                        {
                            courseResponse.UserDisplayName = user.Name + " " + user.Surname;
                        }
                    }

                    courseResponse.Status = EnumHelper.GetDescription(item.CourseInstructorStatus);

                    result.Add(courseResponse);
                }

                return result;
            }

            return await this.GetCourses(email);


        }

        public async Task<bool> ApproveStudent(int id)
        {
            var student = await this.container.Repository<Student>().GetById(id);

            student.StudentStatus = StudentStatus.Approved;
            await this.container.Repository<Student>().Save();

            return true;
        }
    }
}

