using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class  CourseInstructorResponse
    {
        public List<CourseResponse> CourseResponses { get; set; }

        public List<InstructorResponse> InstructorResponses { get; set; }

        public CourseInstructorResponse()
        {
            this.CourseResponses = new List<CourseResponse>();
            this.InstructorResponses=new List<InstructorResponse>();
        }
    }
}
