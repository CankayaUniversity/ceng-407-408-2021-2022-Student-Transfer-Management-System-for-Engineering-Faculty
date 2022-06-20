using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
   public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string SSN { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string University { get; set; }

        public List<FileResponse> FileResponses { get; set; }

        public List<StudentCourseResponse> StudentCourseResponses { get; set; }

        public string Status { get; set; }

        public StudentResponse()
        {
            this.FileResponses = new List<FileResponse>();
            this.StudentCourseResponses = new List<StudentCourseResponse>();
        }
    }
}
