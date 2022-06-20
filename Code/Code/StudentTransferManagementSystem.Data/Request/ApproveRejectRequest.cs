using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Request
{
    public class ApproveRejectRequest
    {
        public int CourseId { get; set; }

        public int UserId { get; set; }
    }
}
