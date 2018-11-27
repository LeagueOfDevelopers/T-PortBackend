using System;
using System.Net.Mail;

namespace TPort.Domain.UserManagement
{
    public class Account
    {
        public string Name { get; }
        
        public string Surname { get; }
        
        public string MiddleName { get; }
        
        public MailAddress Email { get; }
        
        public string Password { get; }    // надо будет создать класс Password
        
        public DateTimeOffset RegistrationTime { get; }
    }
}