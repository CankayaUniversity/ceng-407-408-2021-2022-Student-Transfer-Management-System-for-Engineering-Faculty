using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Enums;
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
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IContainer container;

        public AdminBusiness(IContainer container)
        {
            this.container = container;
        }

        public async Task<UserRoleResponse> GetRoles()
        {
            var users = await this.container.Repository<User>().ListAll();

            var response = new UserRoleResponse();

            foreach (var item in users)
            {
                var userResponse = new UserResponse();
                userResponse.Id = item.Id;
                userResponse.DisplayName = item.Name + " " + item.Surname;
                userResponse.Value = (int)item.UserType;
                response.UserResponses.Add(userResponse);
            }

            var roleList = Enum.GetValues(typeof(UserType))
                       .Cast<UserType>()
                       .Select(v => v.ToString())
                       .ToList();


            foreach (var item in roleList)
            {
                var roleResponse = new RoleResponse();
                roleResponse.Text = item;
                roleResponse.Value = (int)(UserType)Enum.Parse(typeof(UserType), item);
                response.RoleResponses.Add(roleResponse);
            }

            return response;
        }

        public async Task<bool> SaveUserRole(UserRoleRequest request)
        {
            try
            {
                if (request.Value > 0 && request.UserId > 0)
                {
                    var existUser = await this.container.Repository<User>().GetById(request.UserId);

                    existUser.UserType = (UserType)request.Value;

                    await this.container.Repository<User>().Save();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }

        public async Task<List<DepartmentResponse>> GetDepartments()
        {
            var list = await this.container.Repository<Department>().ListAll();

            var result = list.Select(l => new DepartmentResponse
            {
                Code = l.Code,
                Id = l.Id,
                Name = l.Name,
                DepartmentId = l.Id
            }).ToList();

            return result;
        }
    }
}