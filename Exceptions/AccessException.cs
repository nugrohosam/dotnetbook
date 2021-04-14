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
    public class NotAllowedException : HttpRequestException
    {
        public NotAllowedException() : base("Not Allowed")
        {
        }

        public NotAllowedException(string message)
            : base(message)
        {
        }

        public NotAllowedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class RoleNotAssignedException : HttpRequestException
    {
        public RoleNotAssignedException() : base("Role Not Assigned")
        {
        }

        public RoleNotAssignedException(string message)
            : base(message)
        {
        }

        public RoleNotAssignedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class EmailAndPasswordException : HttpRequestException
    {
        public EmailAndPasswordException() : base("Email and Password not match")
        {
        }

        public EmailAndPasswordException(string message)
            : base(message)
        {
        }

        public EmailAndPasswordException(string message, Exception inner)
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
