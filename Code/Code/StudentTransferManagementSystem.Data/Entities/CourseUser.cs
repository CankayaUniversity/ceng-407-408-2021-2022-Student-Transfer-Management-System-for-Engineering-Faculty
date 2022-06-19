using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class CourseUser : BaseEntity
    {
        public int CourseId { get; set; }

        public int UserId { get; set; }
    }
}
