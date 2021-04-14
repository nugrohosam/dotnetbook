using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.RolePermission;
using BookApi.Responses;
using BookApi.Middlewares;
using BookApi.Responses.RolePermission;
using BookApi.Applications.RolePermission;
using System;
using System.Net;

namespace BookApi.Controllers
{
    [Route("api/role-permission")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class RolePermissionController : ControllerBase
    {
        private RolePermissionApplication rolePermissionApplication;

        public RolePermissionController()
        {
            this.rolePermissionApplication = new RolePermissionApplication();
        }

        // GET: api/RolePermission
        [HttpGet(Name = "GetListRolePermission" + Global.SeparatorRoutePermission + Global.GetRolePermission)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                var rolePermissionsRepo = this.rolePermissionApplication.GetList(query.Page, query.PerPage);
                int count = this.rolePermissionApplication.Count();
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = (new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = RolePermissionItem.MapRepo(rolePermissionsRepo),
                    Total = count
                });

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var rolePermissionsRepo = this.rolePermissionApplication.GetList(query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, rolePermissionsRepo, rolePermissionsRepo.Count));
            }
        }

        // GET: api/RolePermission/5
        [HttpGet("{id}", Name = "GetDetailRolePermission" + Global.SeparatorRoutePermission + Global.GetRolePermission)]
        public ApiResponse Show(long id)
        {
            var rolePermissionRepository = this.rolePermissionApplication.DetailById(id);
            return (new ApiResponseData(HttpStatusCode.OK, (new RolePermissionDetail(rolePermissionRepository))));
        }

        // POST: api/RolePermission
        [HttpPost(Name = "CreateRolePermission" + Global.SeparatorRoutePermission + Global.CreateRolePermission)]
        [Consumes("application/json")]
        public ApiResponse Store(RolePermissionCreate rolePermissionCreate)
        {
            this.rolePermissionApplication.CreateFromAPI(rolePermissionCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/RolePermission/5
        [HttpPut("{id}", Name = "UpdateRolePermission" + Global.SeparatorRoutePermission + Global.UpdateRolePermission)]
        [MiddlewareFilter(typeof(DefineRouteValuesGlobaly))]
        public ApiResponse Update(long id, RolePermissionUpdate rolePermissionUpdate)
        {
            this.rolePermissionApplication.UpdateFromAPI(id, rolePermissionUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteRolePermission" + Global.SeparatorRoutePermission + Global.DeleteRolePermission)]
        public ApiResponse Delete(int id)
        {
            this.rolePermissionApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
