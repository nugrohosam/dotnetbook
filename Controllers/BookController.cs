using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Book;
using BookApi.Responses.Book;
using BookApi.Applications.Book;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookApplication bookApplication;
        
        public BookController() {
            this.bookApplication = new BookApplication();
        }

        // GET: api/Book
        [HttpGet(Name = "GetListBook")]
        public BookList Get([FromQuery] Query query, [FromHeader] Header header)
        {
            // var bookRepository = this.bookApplication.DetailById();
            return (new BookList());
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public BookDetail Get(long id)
        {
            var bookRepository = this.bookApplication.DetailById(id);
            if (bookRepository.Id == 0){
                return null;
            }

            return (new BookDetail()).BindRepo(bookRepository);       
        }

        // POST: api/Book
        [HttpPost]
        [Consumes("application/json")]
        public void Post(BookCreate bookCreate)
        {
            this.bookApplication.CreateFromAPI(bookCreate);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(long id, BookCreate bookCreate)
        {
            this.bookApplication.UpdateFromAPI(id, bookCreate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IEnumerable<string> Delete(int id)
        {
            return new string[] { id.ToString() };
        }
    }
}
