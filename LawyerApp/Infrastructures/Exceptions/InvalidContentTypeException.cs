using System;

namespace LawyerApp.Infrastructures
{

    [Serializable]
    public class InvalidContentTypeException : ApplicationException
    {
        public InvalidContentTypeException() { }
        public InvalidContentTypeException(string message) : base(message) { }
        public InvalidContentTypeException(string message, Exception inner) : base(message, inner) { }
        protected InvalidContentTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
