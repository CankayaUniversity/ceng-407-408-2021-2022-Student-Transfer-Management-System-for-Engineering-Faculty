using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class SessionResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Caption { get; set; }

        public bool IsLoginSuccess { get; set; }
    }
}
