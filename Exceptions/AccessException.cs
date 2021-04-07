using System;
using System.Net.Http;

namespace BookApi.Exceptions
{

    public class UnauthorizedAccessException : HttpRequestException
    {
        public UnauthorizedAccessException()
        {
        }

        public UnauthorizedAccessException(string message)
            : base(message)
        {
        }

        public UnauthorizedAccessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
