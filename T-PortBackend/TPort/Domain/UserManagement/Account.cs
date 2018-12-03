using System;
using System.Net.Mail;

namespace TPort.Domain.UserManagement
{
    public class Account
    {
        public Account(Guid id, string firstName, string middleName, string lastName, MailAddress email, 
            string password, DateTimeOffset registrationTime)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            RegistrationTime = registrationTime;
        }

        public Guid Id { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public MailAddress Email { get; }
        
        public string Password { get; }    // надо будет создать класс Password
        
        public DateTimeOffset RegistrationTime { get; }
    }
}