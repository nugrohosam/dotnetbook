using System.ComponentModel.DataAnnotations;
using System;
using BookApi.Applications.Book;
using BookApi.Repositories.Book;

namespace BookApi.Validations.Author
{
    public class IsExists : ValidationAttribute
    {
        BookApplication bookApplication;

        public IsExists(string errorMessage) : base(errorMessage)
        {
            this.bookApplication = new BookApplication();
        }
        
        public override bool IsValid(object value)
        {
            long authorId = Convert.ToInt64(value.ToString());
            BookRepository bookRepository = this.bookApplication.DetailById(authorId);
            return bookRepository.Id > 0;
        }
    }
}