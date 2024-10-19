using Services.AuxiliaryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmailService
    {
        public void SendMail(MailData mailMessage);
    }
}
