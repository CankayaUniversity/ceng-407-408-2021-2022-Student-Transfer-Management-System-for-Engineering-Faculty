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
        Task<List<StudentResponse>> ListAllStudent(string emailAddress);
        Task<List<InstructorResponse>> ListAllInstructor(string email);
        Task<StudentResponse> SelectedStudent(int Id);
        Task<bool> SaveStudent(RegisterRequest request);
        Task<FileResponse> GetFileDetail(int Id);
        Task<StudentResponse> SaveStudentCourse(StudentCourseRequest request);
        Task<List<CourseResponse>> GetCourses(string email);
        Task<List<CourseResponse>> CourseList(string email);
        Task<CourseInstructorResponse> GetCourseViewData(string email);
        Task<bool> SaveCourseUser(CourseUserRequest request);
        Task<List<CourseResponse>> GetCourseApproveDepartmentHead();
        Task<bool> Approve(ApproveRejectRequest request);
        Task<bool> Reject(ApproveRejectRequest request);
        Task<bool> ApproveStudent(int id);
    }
}
