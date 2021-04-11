using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Role;
using System.Collections.Generic;
using BookApi.Repositories.Role;
using BookApi.Middlewares;
using BookApi.Responses;
using BookApi.Responses.Role;
using BookApi.Applications.Role;
using System.Net;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class RoleController : ControllerBase
    {
        private RoleApplication roleApplication;

        public RoleController()
        {
            this.roleApplication = new RoleApplication();
        }

        // GET: api/Role
        [HttpGet(Name = "GetListRole" + Global.SeparatorRoutePermission + Global.GetRole)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<RoleRepository> rolesRepo = this.roleApplication.GetList(query.Search, query.Page, query.PerPage);
                int count = this.roleApplication.Count(query.Search);
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = RoleItem.MapRepo(rolesRepo),
                    Total = count
                };

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var rolesRepo = this.roleApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, rolesRepo, rolesRepo.Count));
            }
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "GetDetailRole" + Global.SeparatorRoutePermission + Global.GetRole)]
        public ApiResponse Show(long id)
        {
            RoleDetail roleDetail = null;
            var roleRepository = this.roleApplication.DetailById(id);
            if (roleRepository.Id != 0)
            {
                roleDetail = new RoleDetail(roleRepository);
            }

            return (new ApiResponseData(HttpStatusCode.OK, roleDetail));
        }
    }
}
