using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Permission;
using System.Collections.Generic;
using BookApi.Repositories.Permission;
using BookApi.Middlewares;
using BookApi.Responses;
using BookApi.Responses.Permission;
using BookApi.Applications.Permission;
using System.Net;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    public class PermissionController : ControllerBase
    {
        private PermissionApplication permissionApplication;

        public PermissionController()
        {
            this.permissionApplication = new PermissionApplication();
        }

        // GET: api/Permission
        [HttpGet(Name = "GetListPermission")]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<PermissionRepository> permissionsRepo = this.permissionApplication.GetList(query.Search, query.Page, query.PerPage);
                PaginationModel paginate = new PaginationModel()
                {
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = PermissionItem.MapRepo(permissionsRepo),
                    Total = permissionsRepo.Count
                };

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var permissionsRepo = this.permissionApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, permissionsRepo, permissionsRepo.Count));
            }
        }

        // GET: api/Permission/5
        [HttpGet("{id}", Name = "GetPermission")]
        public ApiResponse Show(long id)
        {
            PermissionDetail permissionDetail = null;
            var permissionRepository = this.permissionApplication.DetailById(id);
            if (permissionRepository.Id != 0)
            {
                permissionDetail = new PermissionDetail(permissionRepository);
            }

            return (new ApiResponseData(HttpStatusCode.OK, permissionDetail));
        }

        // POST: api/Permission
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse Store(PermissionCreate permissionCreate)
        {
            this.permissionApplication.CreateFromAPI(permissionCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/Permission/5
        [HttpPut("{id}")]
        public ApiResponse Update(long id, PermissionUpdate permissionUpdate)
        {
            this.permissionApplication.UpdateFromAPI(id, permissionUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            this.permissionApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
