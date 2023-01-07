using System;
using System.Net;

namespace CityLibraryInfrastructure.ExceptionHandling
{
    public class CustomException : Exception
    {
        public CustomException(string Message, bool serialized = false)
       : base(Message)
        {
            this.Serialized = serialized;
        }

        public CustomException()
            : this("Internal Server Error!")
        {

        }

        public bool Serialized { get; set; }
    }
}
