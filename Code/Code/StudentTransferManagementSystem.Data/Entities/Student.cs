using StudentTransferManagementSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
   public class Student : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public string University { get; set; }

        public string Ssn { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }

        public StudentStatus StudentStatus { get; set; }
    }

}
