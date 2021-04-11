using System;
using System.Net.Http;

namespace BookApi.Exceptions
{
    public class UnauthorizedException : HttpRequestException
    {
        public UnauthorizedException() : base("Not Authenticated")
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class TokenNotValidException : HttpRequestException
    {
        public TokenNotValidException() : base("Not Valid Token")
        {
        }

        public TokenNotValidException(string message)
            : base(message)
        {
        }

        public TokenNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
