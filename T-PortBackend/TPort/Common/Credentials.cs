using System;
using System.Security.Cryptography;
using System.Text;

namespace TPort.Common
{
    public class Credentials
    {
        public Credentials(string userAgent, string phoneNumber)
        {
            UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        public string PhoneNumber { get; }
        public string UserAgent { get; }
        
        protected bool Equals(Credentials other)
        {
            return string.Equals(PhoneNumber, other.PhoneNumber) && string.Equals(UserAgent, other.UserAgent);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Credentials) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((PhoneNumber != null ? PhoneNumber.GetHashCode() : 0) * 397) ^ (UserAgent != null ? UserAgent.GetHashCode() : 0);
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