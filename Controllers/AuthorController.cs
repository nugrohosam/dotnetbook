using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Author;
using BookApi.Responses.Author;
using BookApi.Applications.Author;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorApplication authorApplication;
        
        public AuthorController() {
            this.authorApplication = new AuthorApplication();
        }

        // GET: api/Author
        [HttpGet(Name = "GetListAuthor")]
        public IEnumerable<string> Get([FromQuery] Query query, [FromHeader] Header header)
        {
            return new string[] { query.search, header.authorization, header.platform, header.locale };
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public AuthorDetail Get(long id)
        {
            var authorRepository = this.authorApplication.DetailById(id);
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
        public IEnumerable<string> Delete(int id)
        {
            return new string[] { id.ToString() };
        }
    }
}
