using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentTransferManagementSystem.Data.Enums
{
    public enum CourseInstructorEnum
    {
        [Description("Waiting")]
        Waiting = 0,

        [Description("Waiting Department Head")]
        WaitingDepartmentHead = 1,

        [Description("Approved Department Head")]
        ApprovedDepartmentHead = 2
    }
}
