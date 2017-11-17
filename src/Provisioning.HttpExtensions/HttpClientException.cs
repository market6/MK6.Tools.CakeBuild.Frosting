using System;
using System.Net;

namespace Provisioning.HttpExtensions
{
    public class HttpClientException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; set; }
        public string ResponseContent { get; set; }

        public HttpClientException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public HttpClientException(string message) : base(message)
        {

        }
    }
}
