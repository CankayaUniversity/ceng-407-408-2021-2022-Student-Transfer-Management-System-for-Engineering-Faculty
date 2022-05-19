using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentTransferManagementSystem.Classes
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IContainer container;

        public AdminBusiness(IContainer container)
        {
            this.container = container;
        }
    }
}