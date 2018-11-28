using System;
using System.Runtime.Serialization;

namespace TPort.Domain.Exceptions
{
    public class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException()
        {
        }

        protected AccountAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AccountAlreadyExistsException(string message) : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}