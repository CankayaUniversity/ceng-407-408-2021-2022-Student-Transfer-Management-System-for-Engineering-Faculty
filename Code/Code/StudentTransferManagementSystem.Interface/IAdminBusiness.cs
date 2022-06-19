using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Interface
{
    public interface IAdminBusiness
    {
        Task<List<DepartmentResponse>> GetDepartments();

        Task<UserRoleResponse> GetRoles();

        Task<bool> SaveUserRole(UserRoleRequest request);
    }
}
