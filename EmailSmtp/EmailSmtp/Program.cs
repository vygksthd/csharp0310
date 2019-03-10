using System;
using System.Net;
using System.Net.Mail;

namespace EmailSmtp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var credentials = new NetworkCredential("vygksthd@gamil.com", "diddl!23");

                var mail = new MailMessage()
                {
                    From = new MailAddress("vygksthd@gamil.com"),
                    Subject = "Test email.",
                    Body = "Test email body"
                };

                mail.To.Add(new MailAddress("vygksthd@naver.com"));

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Email sccessfully sent");
            Console.ReadKey();
        }
    }
}
