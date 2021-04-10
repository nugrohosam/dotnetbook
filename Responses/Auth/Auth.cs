using System;

namespace BookApi.Responses.Auth
{
    public class AuthToken
    {
        public DateTime ExpiredAt { get; set; }

        public string Token { get; set; }
    }
}