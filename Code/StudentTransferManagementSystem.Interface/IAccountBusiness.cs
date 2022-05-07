using StudentTransferManagementSystem.Data.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Interface
{
    public interface IAccountBusiness
    {
        Task<bool> Register(RegisterRequest request);
    }
}
