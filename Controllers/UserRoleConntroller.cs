using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.UserRole;
using BookApi.Responses;
using BookApi.Middlewares;
using BookApi.Responses.UserRole;
using BookApi.Applications.UserRole;
using System;
using System.Net;

namespace BookApi.Controllers
{
    [Route("api/user-role")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class UserRoleController : ControllerBase
    {
        private UserRoleApplication userRoleApplication;

        public UserRoleController()
        {
            this.userRoleApplication = new UserRoleApplication();
        }

        // GET: api/UserRole
        [HttpGet(Name = "GetListUserRole" + Global.SeparatorRoutePermission + Global.GetUserRole)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                var userRolesRepo = this.userRoleApplication.GetList(query.Page, query.PerPage);
                int count = this.userRoleApplication.Count(query.Search);
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = (new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = UserRoleItem.MapRepo(userRolesRepo),
                    Total = count
                });

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var userRolesRepo = this.userRoleApplication.GetList(query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, userRolesRepo, userRolesRepo.Count));
            }
        }

        // GET: api/UserRole/5
        [HttpGet("{id}", Name = "GetDetailUserRole" + Global.SeparatorRoutePermission + Global.GetUserRole)]
        public ApiResponse Show(long id)
        {
            var userRoleRepository = this.userRoleApplication.DetailById(id);
            return (new ApiResponseData(HttpStatusCode.OK, (new UserRoleDetail(userRoleRepository))));
        }

        // POST: api/UserRole
        [HttpPost(Name = "CreateUserRole" + Global.SeparatorRoutePermission + Global.CreateUserRole)]
        [Consumes("application/json")]
        public void Store(UserRoleCreate userRoleCreate)
        {
            this.userRoleApplication.CreateFromAPI(userRoleCreate);
        }

        // PUT: api/UserRole/5
        [HttpPut("{id}", Name = "UpdateUserRole" + Global.SeparatorRoutePermission + Global.UpdateUserRole)]
        public void Update(long id, UserRoleUpdate userRoleUpdate)
        {
            this.userRoleApplication.UpdateFromAPI(id, userRoleUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteUserRole" + Global.SeparatorRoutePermission + Global.DeleteUserRole)]
        public ApiResponse Delete(int id)
        {
            this.userRoleApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
