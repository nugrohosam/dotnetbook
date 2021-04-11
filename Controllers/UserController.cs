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
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class UserController : ControllerBase
    {
        private UserApplication userApplication;

        public UserController()
        {
            this.userApplication = new UserApplication();
        }

        // GET: api/User
        [HttpGet(Name = "GetListUser" + Global.SeparatorRoutePermission + Global.GetUser)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<UserRepository> usersRepo = this.userApplication.GetList(query.Search, query.Page, query.PerPage);
                int count = this.userApplication.Count(query.Search);
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = UserItem.MapRepo(usersRepo),
                    Total = count
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
        [HttpGet("{id}", Name = "GetDetailUser" + Global.SeparatorRoutePermission + Global.GetUser)]
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

        // PUT: api/User/5
        [HttpPut("{id}", Name = "UpdateUser" + Global.SeparatorRoutePermission + Global.UpdateUser)]
        public ApiResponse Update(long id, UserUpdate userUpdate)
        {
            this.userApplication.UpdateFromAPI(id, userUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteUser" + Global.SeparatorRoutePermission + Global.DeleteUser)]
        public ApiResponse Delete(int id)
        {
            this.userApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
