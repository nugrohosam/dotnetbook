using System;

namespace BookApi.Repositories.Auth
{
    public class AuthRepository
    {
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}