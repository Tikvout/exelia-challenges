using System;
using System.Runtime.Serialization;

namespace _4_web_based_backend.Data
{
    [Serializable]
    internal class ArgumentNullExeption : Exception
    {
        public ArgumentNullExeption()
        {
        }

        public ArgumentNullExeption(string message) : base(message)
        {
        }

        public ArgumentNullExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentNullExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}