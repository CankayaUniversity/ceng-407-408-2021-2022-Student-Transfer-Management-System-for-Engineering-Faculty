using StudentTransferManagementSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Ssn { get; set; }

        public UserTypes UserTypes { get; set; }
    }
}
