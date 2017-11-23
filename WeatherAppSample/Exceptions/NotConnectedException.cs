using System;
namespace WeatherAppSample.Exceptions
{
    class NotConnectedException : Exception
    {
        public NotConnectedException()
        {
        }
        public NotConnectedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
