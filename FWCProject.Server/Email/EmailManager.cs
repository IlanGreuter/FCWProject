using MailKit.Net.Smtp;
using MimeKit;

namespace FCWProject.Util
{
    public static class EmailManager
    {
        private const string EMAIL_SENDER = "your@gmail.com";
        private const string EMAIL_SENDER_PW = "Your password";
        private const string EMAIL_RECEIVER = "receiver@mail.com";

        public static void SendNotification(string message)
        {
            try
            {
                MimeMessage mail = new();
                mail.From.Add(new MailboxAddress("Sender", EMAIL_SENDER));
                mail.To.Add(new MailboxAddress("recipient", EMAIL_RECEIVER));
                mail.Subject = "Message for you!";
                mail.Body = new TextPart("plain")
                {
                    Text = message
                };

                using SmtpClient client = new();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(EMAIL_SENDER, EMAIL_SENDER_PW);
                client.Send(mail);
                client.Disconnect(true);
            }
            catch
            {
                Console.WriteLine($"Failed attempt to send mail with message: {message}");
            }
        }
    }
}
