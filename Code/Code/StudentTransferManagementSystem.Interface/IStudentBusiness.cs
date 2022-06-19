using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace StudentTransferManagementSystem.Interface
{
    public interface IStudentBusiness
    {
        Task<List<StudentResponse>> ListAllStudent();
        Task<StudentResponse> SelectedStudent(int Id);
        Task<bool> SaveStudent(RegisterRequest request);
        Task<FileResponse> GetFileDetail(int Id);
        Task<StudentResponse> SaveStudentCourse(StudentCourseRequest request);

        Task<List<CourseResponse>> GetCourses();

        Task<CourseInstructorResponse> GetCourseViewData();

        Task<bool> SaveCourseUser(CourseUserRequest request);
      


        Task<List<CourseResponse>> GetCourseApproveDepartmentHead();
    }
}
