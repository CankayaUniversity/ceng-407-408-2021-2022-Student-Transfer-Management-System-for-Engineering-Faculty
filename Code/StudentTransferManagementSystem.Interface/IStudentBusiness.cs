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
        public Task<List<StudentResponse>> ListAllStudent();
        public Task<StudentResponse> SelectedStudent(int Id);
    }
}
