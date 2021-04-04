using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Requests;
using System.Diagnostics;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public IEnumerable<string> Get([FromQuery(Name = "search")] string search, [FromQuery(Name = "pagination")] bool pagination)
        {
            Debug.WriteLine(search);
            Debug.WriteLine(pagination);
            return new string[] { search, (pagination ? "true" : "false") };
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
