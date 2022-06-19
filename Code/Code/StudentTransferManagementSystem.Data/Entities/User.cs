using StudentTransferManagementSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string RegistrationNumber { get; set; }

        public string Caption { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }

        public UserType UserType { get; set; }
    }
}
