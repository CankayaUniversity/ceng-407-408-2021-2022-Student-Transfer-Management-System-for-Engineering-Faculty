using StudentTransferManagementSystem.Classes.Helper;
using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Data.Request;
using StudentTransferManagementSystem.Data.Responses;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentTransferManagementSystem.Classes
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IContainer container;

        public AccountBusiness(IContainer container)
        {
            this.container = container;
        }

        public async Task<SessionResponse> Login(LoginRequest request)
        {
            var result = WebServiceHelper.CallWebService();

            var session = new SessionResponse();
            var existUser = result.Where(l => l.Email == request.Email && l.SicilNo == request.RegistrationNumber).FirstOrDefault();

            if (existUser == null)
            {
                session.IsLoginSuccess = false;
                return session;
            }

            session.Caption = existUser.UnvAd;
            session.Name = existUser.PerAd + " " + existUser.PerSoyad;
            session.IsLoginSuccess = true;
            session.Email = existUser.Email;

            return session;
        }
    }
}
