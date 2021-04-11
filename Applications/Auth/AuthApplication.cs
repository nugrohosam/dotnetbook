using BookApi.Requests.Auth;
using BookApi.Repositories.User;
using BookApi.Exceptions;
using BookApi.Repositories.Auth;
using System;

namespace BookApi.Applications.Auth
{
    public class AuthApplication
    {
        private UserQueryRepository userQueryRepository;

        public AuthApplication()
        {
            this.userQueryRepository = new UserQueryRepository();
        }

        public AuthRepository SignInFromAPI(AuthSignIn authSignIn)
        {
            UserRepository userRepo = this.userQueryRepository.FindByEmail(authSignIn.Email);
            if (userRepo.Email == null)
            {
                throw (new DataNotFoundException("Email"));
            }

            DateTime expiredAt = DateTime.UtcNow.AddDays(7);
            return new AuthRepository()
            {
                ExpiredAt = expiredAt,
                Token = AuthUtility.GenerateJwtToken(userRepo.Email)
            };
        }
        public bool ValidateToken(string token)
        {
            string email = AuthUtility.ValidateJwtToken(token);
            if (email == null)
            {
                return false;
            }

            Global.emailUser = email;
            return true;
        }
    }
}