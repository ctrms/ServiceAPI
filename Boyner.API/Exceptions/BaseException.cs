using System;
using System.Net;
using System.Runtime.Serialization;

namespace Boyner.API.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }
        public abstract bool IsLogSave { get; }
        protected BaseException() : base()
        {
        }

        protected BaseException(string message) : base(message)
        {
        }

        protected BaseException(string message, Exception exception) : base(message, exception)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
