using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class ResponsibleCourses : BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public int ResponsibleInstructorId { get; set; }
    
    }
}
