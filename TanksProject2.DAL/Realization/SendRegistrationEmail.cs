using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Interfaces;
using System.Net;
using MimeKit;

namespace TanksProject2.DAL.Realization
{
    public class SendRegistrationEmail : ISendRegistrationEmail
    {
        public async Task FuncSendRegistrationEmail(string recipientEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TanksProject", "jonyfudiplercken@mail.ru"));
            message.To.Add(new MailboxAddress("Dr", recipientEmail));
            message.Subject = "Registration";

            var text = new TextPart("plain")
            {
                Text = "Вы зарегистрировались на TanksProject. ",
            };

            
            message.Body = text;

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("jonyfudiplercken@mail.ru", "s6UiPU40T1R76aTCeYmc");

                
                await client.SendAsync(message);

                
                client.Disconnect(true);


            }
        }
    }
}
