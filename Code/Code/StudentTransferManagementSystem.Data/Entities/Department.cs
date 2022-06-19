using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public class Department : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
