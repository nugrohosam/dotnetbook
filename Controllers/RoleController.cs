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
    public class RoleController : ControllerBase
    {
        private RoleApplication roleApplication;

        public RoleController()
        {
            this.roleApplication = new RoleApplication();
        }

        // GET: api/Role
        [HttpGet(Name = "GetListRole")]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<RoleRepository> rolesRepo = this.roleApplication.GetList(query.Search, query.Page, query.PerPage);
                PaginationModel paginate = new PaginationModel()
                {
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = RoleItem.MapRepo(rolesRepo),
                    Total = rolesRepo.Count
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
        [HttpGet("{id}", Name = "GetRole")]
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

        // POST: api/Role
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse Store(RoleCreate roleCreate)
        {
            this.roleApplication.CreateFromAPI(roleCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public ApiResponse Update(long id, RoleUpdate roleUpdate)
        {
            this.roleApplication.UpdateFromAPI(id, roleUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            this.roleApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
