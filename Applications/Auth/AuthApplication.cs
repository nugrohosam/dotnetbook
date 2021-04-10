using BookApi.Requests.Auth;
using BookApi.Repositories.User;
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
            DateTime expiredAt = DateTime.UtcNow.AddDays(7);
            return new AuthRepository()
            {
                ExpiredAt = expiredAt,
                Token = AuthUtility.GenerateJwtToken(userRepo.Email)
            };
        }
    }
}