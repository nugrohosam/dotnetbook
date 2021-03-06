using Microsoft.AspNetCore.Mvc;
using BookApi.Requests;
using BookApi.Requests.Book;
using System.Collections.Generic;
using BookApi.Repositories.Book;
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
    [MiddlewareFilter(typeof(AuthorizationCheck))]
    [MiddlewareFilter(typeof(AuthorizationRole))]
    public class BookController : ControllerBase
    {
        private BookApplication bookApplication;

        public BookController()
        {
            this.bookApplication = new BookApplication();
        }

        // GET: api/Book
        [HttpGet(Name = "GetListBook" + Global.SeparatorRoutePermission + Global.GetBook)]
        public ApiResponse Index([FromQuery] Query query, [FromHeader] Header header)
        {
            if (query.Pagination)
            {

                List<BookRepository> booksRepo = this.bookApplication.GetList(query.Search, query.Page, query.PerPage);
                int count = this.bookApplication.Count(query.Search);
                decimal pageInCount = ((decimal)count) / query.PerPage;
                PaginationModel paginate = new PaginationModel()
                {
                    TotalPage = (int)Math.Ceiling(pageInCount),
                    Page = query.Page,
                    PerPage = query.PerPage,
                    Data = BookItem.MapRepo(booksRepo),
                    Total = count
                };

                return (new ApiResponsePagination(HttpStatusCode.OK, paginate));
            }
            else
            {
                var booksRepo = this.bookApplication.GetList(query.Search, query.Page, query.PerPage);
                return (new ApiResponseDataList(HttpStatusCode.OK, booksRepo, booksRepo.Count));
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetDetail" + Global.SeparatorRoutePermission + Global.GetBook)]
        public ApiResponse Show(long id)
        {
            BookDetail bookDetail = null;
            var bookRepository = this.bookApplication.DetailById(id);
            if (bookRepository.Id != 0)
            {
                bookDetail = new BookDetail(bookRepository);
            }

            return (new ApiResponseData(HttpStatusCode.OK, bookDetail));
        }

        // POST: api/Book
        [HttpPost(Name = "CreateBook" + Global.SeparatorRoutePermission + Global.GetBook)]
        [Consumes("application/json")]
        public ApiResponse Store(BookCreate bookCreate)
        {
            this.bookApplication.CreateFromAPI(bookCreate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // PUT: api/Book/5
        [HttpPost("{id}", Name = "UpdateBook" + Global.SeparatorRoutePermission + Global.UpdateBook)]
        public ApiResponse Update(long id, BookUpdate bookUpdate)
        {
            this.bookApplication.UpdateFromAPI(id, bookUpdate);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteBook" + Global.SeparatorRoutePermission + Global.DeleteBook)]
        public ApiResponse Delete(int id)
        {
            this.bookApplication.DeleteFromAPI(id);
            return (new ApiResponseData(HttpStatusCode.OK, null));
        }
    }
}
