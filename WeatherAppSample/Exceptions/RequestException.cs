using System;
namespace WeatherAppSample.Exceptions
{
    public class RequestException : Exception
    {
        public RequestException()
        {
        }
        public RequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
