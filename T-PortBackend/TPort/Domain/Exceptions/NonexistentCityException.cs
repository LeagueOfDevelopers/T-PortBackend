using System;
using System.Runtime.Serialization;

namespace TPort.Domain.Exceptions
{
    public class NonexistentCityException : Exception
    {
        public NonexistentCityException()
        {
        }

        protected NonexistentCityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NonexistentCityException(string message) : base(message)
        {
        }

        public NonexistentCityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}