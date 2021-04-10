
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookApi.Responses
{
    public class Validation
    {
        public string Key;
        public object Value;
    }

    public class ErrorValidation
    {
        public static List<Validation> Error(ActionContext actionContext)
        {
            List<KeyValuePair<string, ModelStateEntry>> errors = actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .ToList();

            List<Validation> errorParsed = new List<Validation>();
            foreach (KeyValuePair<string, ModelStateEntry> error in errors)
            {
                Validation errorData = new Validation
                {
                    Key = error.Key,
                    Value = error.Value
                };

                errorParsed.Add(errorData);
            }

            return errorParsed;
        }
    }
}