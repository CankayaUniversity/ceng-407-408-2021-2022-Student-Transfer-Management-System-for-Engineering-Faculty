using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentTransferManagementSystem.Data.Enums
{
    public enum UserType
    {
        [Description("Instructor")]
        Instructor = 1,

        [Description("Coordinator")]
        Coordinator = 2,

        [Description("Admin")]
        Admin = 3,

        [Description("Department Head")]
        DepartmentHead = 4
    }
}
