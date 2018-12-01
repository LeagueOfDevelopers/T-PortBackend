using System;
using System.Net.Mail;

namespace TPort.Domain.UserManagement
{
    public class Account
    {
        public Account(Guid id, string firstName, string lastName, Credentials userCredentials,
            DateTimeOffset registrationTime)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            UserCredentials = userCredentials ?? throw new ArgumentNullException(nameof(userCredentials));
            RegistrationTime = registrationTime;
        }

        public Guid Id { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public Credentials UserCredentials { get; }
        
        public DateTimeOffset RegistrationTime { get; }
    }
}