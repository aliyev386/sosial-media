using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Admin
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public List<Post> Posts;
        public List<User> Users;

        public Admin() { }
        public Admin(string id, string username, string gmail, string password, List<Post> posts)
        {
            Id = id;
            Username = username;
            Gmail = gmail;
            Password = password;
            Posts = posts;
        }

        public static void SendEmail(string fromEmail, string appPassword, string toEmail, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
                Console.WriteLine("Email uğurla göndərildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xəta baş verdi: " + ex.Message);
            }
        }
        public Post SearchPostId(string id)
        {
            foreach (var post in Posts)
            {
                if (post.Id == id)
                {
                    return post;
                }
            }
            return null;
        }
        
    }
}
