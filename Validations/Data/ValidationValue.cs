using System.ComponentModel.DataAnnotations;
using System;

namespace BookApi.Validations.Data
{
    public class IsNotZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            long data = Convert.ToInt64(value.ToString());
            return data != 0;
        }
    }
    
    public class IsMoreThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            long data = Convert.ToInt64(value.ToString());
            return data > 0;
        }
    }
}