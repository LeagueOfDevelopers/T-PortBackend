using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace TPort.Common
{
    public class Credentials
    {
        public Credentials(MailAddress email, string passwordHash)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }

        public MailAddress Email { get; }
        public string PasswordHash { get; }

        public static Credentials FromRawData(MailAddress email, string rawPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                var passwordHash = Encoding.UTF8.GetString(hashBytes);
                return new Credentials(email, passwordHash);
            }
        }
        
        protected bool Equals(Credentials other)
        {
            return Email.Equals(other.Email) && string.Equals(PasswordHash, other.PasswordHash);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Credentials) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Email.GetHashCode() * 397) ^ PasswordHash.GetHashCode();
            }
        }

        public static bool operator ==(Credentials left, Credentials right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Credentials left, Credentials right)
        {
            return !Equals(left, right);
        }
    }
}