using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Author;
using BookApi.Responses;
using BookApi.Responses.Author;
using BookApi.Applications.Author;
using System;
using System.Net;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorApplication authorApplication;

        public AuthorController()
        {
            this.authorApplication = new AuthorApplication();
        }

        // GET: api/Author
        [HttpGet(Name = "GetListAuthor")]
        public ApiResponse Get([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                var authorsRepo = this.authorApplication.PaginateData(query.Search, query.Page, query.PerPage);
                PaginationModel paginate = (new PaginationModel()
                {
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = (new AuthorItem()).MapRepo(authorsRepo),
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
        [HttpGet("{id}", Name = "GetAuthor")]
        public AuthorDetail Get(long id)
        {
            var authorRepository = this.authorApplication.DetailById(id);
            if (authorRepository.Id == 0){
                return null;
            }
            
            return (new AuthorDetail()).BindRepo(authorRepository);
        }

        // POST: api/Author
        [HttpPost]
        [Consumes("application/json")]
        public void Post(AuthorCreate authorCreate)
        {
            this.authorApplication.CreateFromAPI(authorCreate);
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public void Put(long id, AuthorCreate authorCreate)
        {
            this.authorApplication.UpdateFromAPI(id, authorCreate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            this.authorApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
