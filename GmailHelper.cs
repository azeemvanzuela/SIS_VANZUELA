using System.Net;
using System.Net.Mail;

public class GmailHelper
{
    private static string SenderEmail = "cvgedoquio@gmail.com"; // your Gmail
    private static string SenderName = "Your App";              // display name
    private static string AppPassword = "smmwyalvckgrufsn";   // generated App Password

   public static void SendEmail(string to, string subject, string body)
    {
        var fromAddress = new MailAddress(SenderEmail, SenderName);
        var toAddress = new MailAddress(to);

        using (var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(SenderEmail, AppPassword)
        })
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}