using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Author;
using BookApi.Responses;
using BookApi.Middlewares;
using BookApi.Responses.Author;
using BookApi.Applications.Author;
using System;
using System.Net;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class AuthorController : ControllerBase
    {
        private AuthorApplication authorApplication;

        public AuthorController()
        {
            this.authorApplication = new AuthorApplication();
        }

        // GET: api/Author
        [HttpGet(Name = "GetListAuthor" + Global.SeparatorRoutePermission + Global.GetAuthor)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                var authorsRepo = this.authorApplication.GetList(query.Search, query.Page, query.PerPage);
                int count = this.authorApplication.Count(query.Search);
                decimal pageInCount = count / query.PerPage;
                PaginationModel paginate = (new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = AuthorItem.MapRepo(authorsRepo),
                    Total = authorsRepo.Count
                });

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var authorsRepo = this.authorApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, authorsRepo, authorsRepo.Count));
            }
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetDetailAuthor" + Global.SeparatorRoutePermission + Global.GetAuthor)]
        public ApiResponse Show(long id)
        {
            var authorRepository = this.authorApplication.DetailById(id);
            if (authorRepository.Id == 0)
            {
                return null;
            }

            return (new ApiResponseData(HttpStatusCode.OK, (new AuthorDetail(authorRepository))));
        }

        // POST: api/Author
        [HttpPost(Name = "CreateAuthor" + Global.SeparatorRoutePermission + Global.CreateAuthor)]
        [Consumes("application/json")]
        public void Store(AuthorCreate authorCreate)
        {
            this.authorApplication.CreateFromAPI(authorCreate);
        }

        // PUT: api/Author/5
        [HttpPut("{id}", Name = "UpdateAuthor" + Global.SeparatorRoutePermission + Global.UpdateAuthor)]
        public void Update(long id, AuthorUpdate authorUpdate)
        {
            this.authorApplication.UpdateFromAPI(id, authorUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteAuthor" + Global.SeparatorRoutePermission + Global.DeleteAuthor)]
        public ApiResponse Delete(int id)
        {
            this.authorApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
