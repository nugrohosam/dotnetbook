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
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class PermissionController : ControllerBase
    {
        private PermissionApplication permissionApplication;

        public PermissionController()
        {
            this.permissionApplication = new PermissionApplication();
        }

        // GET: api/Permission
        [HttpGet(Name = "GetListPermission" + Global.SeparatorRoutePermission + Global.GetPermission)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                List<PermissionRepository> permissionsRepo = this.permissionApplication.GetList(query.Search, query.Page, query.PerPage);
                int count = this.permissionApplication.Count(query.Search);
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = PermissionItem.MapRepo(permissionsRepo),
                    Total = count
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
        [HttpGet("{id}", Name = "GetDetailPermission" + Global.SeparatorRoutePermission + Global.GetPermission)]
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
    }
}
