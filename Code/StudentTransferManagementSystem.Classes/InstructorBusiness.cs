using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Enums;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace StudentTransferManagementSystem.Classes
{
    public class InstructorBusiness : IInstructorBusiness
    {
        private readonly IContainer container;

        public InstructorBusiness(IContainer container)
        {
            this.container = container;
        }


        }
    }



    

