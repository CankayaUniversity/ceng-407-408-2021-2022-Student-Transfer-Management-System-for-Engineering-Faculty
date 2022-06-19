using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public  class CourseResponse
    {
        public CourseResponse()
        {
        }

        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public string Credit { get; set; }
        public string AKTS { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public string UserDisplayName { get; set; }
    }
}
