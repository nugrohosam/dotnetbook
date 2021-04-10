using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.User;
using System.Collections.Generic;
using BookApi.Repositories.User;
using BookApi.Middlewares;
using BookApi.Responses;
using BookApi.Responses.User;
using BookApi.Applications.User;
using System.Net;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    public class UserController : ControllerBase
    {
        private UserApplication userApplication;

        public UserController()
        {
            this.userApplication = new UserApplication();
        }

        // GET: api/User
        [HttpGet(Name = "GetListUser")]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<UserRepository> usersRepo = this.userApplication.GetList(query.Search, query.Page, query.PerPage);
                PaginationModel paginate = new PaginationModel()
                {
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = UserItem.MapRepo(usersRepo),
                    Total = usersRepo.Count
                };

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var usersRepo = this.userApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, usersRepo, usersRepo.Count));
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public ApiResponse Show(long id)
        {
            UserDetail userDetail = null;
            var userRepository = this.userApplication.DetailById(id);
            if (userRepository.Id != 0)
            {
                userDetail = new UserDetail(userRepository);
            }

            return (new ApiResponseData(HttpStatusCode.OK, userDetail));
        }

        // POST: api/User
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse Store(UserCreate userCreate)
        {
            this.userApplication.CreateFromAPI(userCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ApiResponse Update(long id, UserUpdate userUpdate)
        {
            this.userApplication.UpdateFromAPI(id, userUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            this.userApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
