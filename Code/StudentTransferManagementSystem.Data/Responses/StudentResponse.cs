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

        public string Display { get; set; }
    }
}
