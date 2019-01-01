using System;
using System.Security.Cryptography;
using System.Text;

namespace TPort.Common
{
    public class Credentials
    {
        public Credentials(string userAgentHash, string phoneNumber)
        {
            UserAgentHash = userAgentHash ?? throw new ArgumentNullException(nameof(userAgentHash));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        public string PhoneNumber { get; }
        public string UserAgentHash { get; }

        public static Credentials FromRawData(string phoneNumber, string rawUserAgent)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawUserAgent));
                var userAgentHash = Encoding.UTF8.GetString(hashBytes);
                return new Credentials(phoneNumber, userAgentHash);
            }
        }
        
        protected bool Equals(Credentials other)
        {
            return string.Equals(PhoneNumber, other.PhoneNumber) && string.Equals(UserAgentHash, other.UserAgentHash);
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
                return ((PhoneNumber != null ? PhoneNumber.GetHashCode() : 0) * 397) ^ (UserAgentHash != null ? UserAgentHash.GetHashCode() : 0);
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