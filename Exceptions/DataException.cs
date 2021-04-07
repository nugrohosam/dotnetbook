using System;
using System.Net.Http;

namespace BookApi.Exceptions
{

    public class DataException : HttpRequestException
    {
        public DataException()
        {
        }

        public DataException(string message)
            : base(message)
        {
        }

        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
