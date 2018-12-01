using System;
using System.Net.Mail;

namespace TPort.Domain.UserManagement
{
    public class Credentials
    {
        public Credentials(MailAddress email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public MailAddress Email { get; }
        
        public string Password { get; }
    }
}