using System;
using System.Net;
using System.Net.Mail;

namespace CourseReportEmailer.Workers
{
    class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587; // default
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true; // or you can use your own

            client.EnableSsl = true;
            MailMessage message = new MailMessage("god.above@gmail.com", "gatman946@gmail.com");
            message.Subject = "Enrollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hi,<br><br>Please find the enrollment details report attached.<br><br>Best,<br>Simon";

            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);
            client.Send(message);
        }
    }
}
