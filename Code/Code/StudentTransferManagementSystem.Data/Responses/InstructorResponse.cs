using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class InstructorResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string DisplayName { get; set; }
    }
}
