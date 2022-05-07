using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Classes
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IContainer container;

        public AccountBusiness(IContainer container)
        {
            this.container = container;
        }
        public async Task<bool> Register(RegisterRequest request)
        {
            try
            {
                var studentUser = new User
                {
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,
                    Email = request.Email,
                    ModificationBy = "",
                    Name = request.Name,
                    Surname = request.Surname,
                    Password = request.Password,
                    Ssn = request.Ssn,
                    UserTypes = Data.Enums.UserTypes.Student
                };

                await this.container.Repository<User>().Add(studentUser);
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
    }
}
