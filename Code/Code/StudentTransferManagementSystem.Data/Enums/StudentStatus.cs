using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentTransferManagementSystem.Data.Enums
{
    public enum StudentStatus
    {
        [Description("Approve Waiting")]
        ApproveWaiting = 0,

        [Description("Approved")]
        Approved = 1
    }
}
