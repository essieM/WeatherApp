using System;
namespace WeatherAppSample.Exceptions
{
    class WebException : Exception
    {

        public WebException()
        {
        }

        public WebException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
