using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Request
{
    public class RegisterRequest
    {
        public string Name  { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FacultyId { get; set; }

        public string Ssn { get; set; }

        public string University { get; set; }
        public int DepartmentId { get; set; }

        public List<IFormFile> File { get; set; }
    }
}
