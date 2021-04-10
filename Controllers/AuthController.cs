using Microsoft.AspNetCore.Mvc;
using BookApi.Requests.Auth;
using BookApi.Repositories.Auth;
using BookApi.Responses.Auth;
using System.Net;
using BookApi.Middlewares;
using BookApi.Applications.Auth;

namespace BookApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthApplication authApplication;

        public AuthController()
        {
            this.authApplication = new AuthApplication();
        }

        // GET: api/Book
        [Route("api/[controller]/sign-in")]
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse SignIn([FromBody] AuthSignIn authSignIn)
        {
            AuthRepository authRepository = this.authApplication.SignInFromAPI(authSignIn);
            AuthToken authToken = new AuthToken() {
                Token = authRepository.Token,
                ExpiredAt = authRepository.ExpiredAt
            };
            
            return (new ApiResponseData(HttpStatusCode.OK, authToken));
        }
    }
}
