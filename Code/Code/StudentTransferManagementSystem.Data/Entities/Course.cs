using StudentTransferManagementSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class Course : BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }  
        public string Type { get; set; }    
        public string Time { get; set; }
        public string Credit { get; set;}
        public string AKTS { get; set; }
        public int DepartmentId { get; set; }

        public CourseInstructorEnum CourseInstructorStatus { get; set; }
        //public int InstructorId { get; set; }

    }
}
