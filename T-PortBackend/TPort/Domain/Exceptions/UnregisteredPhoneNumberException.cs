using System;
using System.Runtime.Serialization;

namespace TPort.Domain.Exceptions
{
    public class UnregisteredPhoneNumberException : Exception
    {
        public UnregisteredPhoneNumberException()
        {
        }

        protected UnregisteredPhoneNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnregisteredPhoneNumberException(string message) : base(message)
        {
        }

        public UnregisteredPhoneNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}