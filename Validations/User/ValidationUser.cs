using System.ComponentModel.DataAnnotations;
using System;
using BookApi.Applications.User;
using BookApi.Repositories.User;

namespace BookApi.Validations.User
{
    public class IsExists : ValidationAttribute
    {
        UserApplication userApplication;

        public IsExists(string errorMessage) : base(errorMessage)
        {
            this.userApplication = new UserApplication();
        }
        
        public override bool IsValid(object value)
        {
            long userId = Convert.ToInt64(value.ToString());
            UserRepository userRepository = this.userApplication.DetailById(userId);
            return userRepository.Id > 0;
        }
    }
}