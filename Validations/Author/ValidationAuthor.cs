using System.ComponentModel.DataAnnotations;
using System;
using BookApi.Applications.Author;
using BookApi.Repositories.Author;

namespace BookApi.Validations.Author
{
    public class IsExists : ValidationAttribute
    {
        AuthorApplication authorApplication;

        public IsExists(string errorMessage) : base(errorMessage)
        {
            this.authorApplication = new AuthorApplication();
        }
        
        public override bool IsValid(object value)
        {
            long authorId = Convert.ToInt64(value.ToString());
            AuthorRepository authorRepository = this.authorApplication.DetailById(authorId);
            return authorRepository.Id > 0;
        }
    }
}