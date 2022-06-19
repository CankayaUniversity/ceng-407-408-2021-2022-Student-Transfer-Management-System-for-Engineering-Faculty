using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Request
{
   public class LoginRequest
    {
        public string Email { get; set; }
        public int RegistrationNumber { get; set; }
    }
}
