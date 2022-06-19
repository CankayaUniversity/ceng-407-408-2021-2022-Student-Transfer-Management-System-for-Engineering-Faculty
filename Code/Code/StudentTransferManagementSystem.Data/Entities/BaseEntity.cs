using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModificationBy { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
