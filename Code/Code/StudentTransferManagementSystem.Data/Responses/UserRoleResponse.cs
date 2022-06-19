using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class UserRoleResponse
    {
        public List<UserResponse> UserResponses { get; set; }

        public List<RoleResponse> RoleResponses { get; set; }

        public UserRoleResponse()
        {
            this.RoleResponses = new List<RoleResponse>();
            this.UserResponses = new List<UserResponse>();
        }
    }
}
