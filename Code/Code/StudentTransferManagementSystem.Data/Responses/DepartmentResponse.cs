using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
   public class DepartmentResponse
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? DepartmentId { get; set; }
    }
}
