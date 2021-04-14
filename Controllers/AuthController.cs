using Microsoft.AspNetCore.Mvc;
using BookApi.Requests.Auth;
using BookApi.Repositories.Auth;
using BookApi.Responses.Auth;
using System.Net;
using BookApi.Applications.Auth;
using BookApi.Applications.User;

namespace BookApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthApplication authApplication;
        private UserApplication userApplication;

        public AuthController()
        {
            this.authApplication = new AuthApplication();
            this.userApplication = new UserApplication();
        }

        // GET: api/Book
        [Route("api/[controller]/sign-in")]
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse SignIn( AuthSignIn authSignIn)
        {
            AuthRepository authRepository = this.authApplication.SignInFromAPI(authSignIn);
            AuthToken authToken = new AuthToken()
            {
                Token = authRepository.Token,
                ExpiredAt = authRepository.ExpiredAt
            };

            return (new ApiResponseData(HttpStatusCode.OK, authToken));
        }

        [Route("api/[controller]/register")]
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse Register( AuthRegister authRegister)
        {
            this.userApplication.RegisterFromAPI(authRegister);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
