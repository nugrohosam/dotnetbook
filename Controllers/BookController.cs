using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Book;
using BookApi.Middlewares;
using BookApi.Responses;
using BookApi.Responses.Book;
using BookApi.Applications.Book;
using System.Net;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MiddlewareFilter(typeof(Middlewares.Authorization))]
    public class BookController : ControllerBase
    {
        private BookApplication bookApplication;

        public BookController()
        {
            this.bookApplication = new BookApplication();
        }

        // GET: api/Book
        [HttpGet(Name = "GetListBook")]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {
                var booksRepo = this.bookApplication.PaginateData(query.Search, query.Page, query.PerPage);
                PaginationModel paginate = (new PaginationModel()
                {
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = (new BookItem()).MapRepo(booksRepo),
                    Total = booksRepo.Count
                });

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var booksRepo = this.bookApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, booksRepo, booksRepo.Count));
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public ApiResponse Show(long id)
        {
            var bookRepository = this.bookApplication.DetailById(id);
            if (bookRepository.Id == 0)
            {
                return (new ApiResponseData(HttpStatusCode.OK, null));
            }

            BookDetail bookDetail = (new BookDetail()).BindRepo(bookRepository);
            return (new ApiResponseData(HttpStatusCode.OK, bookDetail));
        }

        // POST: api/Book
        [HttpPost]
        [Consumes("application/json")]
        public ApiResponse Store(BookCreate bookCreate)
        {
            this.bookApplication.CreateFromAPI(bookCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ApiResponse Update(long id, BookCreate bookCreate)
        {
            this.bookApplication.UpdateFromAPI(id, bookCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            this.bookApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
