using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace StudentTransferManagementSystem.Classes.Helper
{
    public static class MailSender
    {
        public static void Send(string email, string message)
        {
            try
            {
                MailMessage mailim = new MailMessage();
                mailim.To.Add(email);
                mailim.From = new MailAddress("cankayabitirmetest@hotmail.com");
                mailim.Subject = "Approve Course" + message;
                mailim.Body = "Sistemde Onaylamanız Gereken Dersler vardır. Derse Kodu :  " + message;

                mailim.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("cankayabitirmetest@hotmail.com", "STMS2022");
                smtp.Port = 587;
                smtp.Host = "smtp.outlook.com";
                smtp.EnableSsl = true;
                smtp.Send(mailim);
            }
            catch (Exception ex)
            {
            }
        }
    }


}
