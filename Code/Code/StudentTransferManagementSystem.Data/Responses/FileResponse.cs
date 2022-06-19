using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class FileResponse
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }

        public string FileContenType { get; set; }
    }
}
