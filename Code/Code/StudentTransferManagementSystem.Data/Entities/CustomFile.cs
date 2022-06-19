using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Entities
{
    public  class CustomFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileContent { get; set; }
        public int StudentId { get; set; }
    }
}
