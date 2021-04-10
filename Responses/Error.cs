
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookApi.Responses
{
    public class Validation
    {
        public string Key;
        public string Value;

        public IDictionary<string, string> ConvertToDictionary()
        {
            IDictionary<string, string> validationParsed = new Dictionary<string, string>();
            validationParsed.Add("key", this.Key);
            validationParsed.Add("value", this.Value);

            return validationParsed;
        }
    }

    public class ErrorValidation
    {
        public static List<IDictionary<string, string>> Error(ActionContext actionContext)
        {
            List<KeyValuePair<string, ModelStateEntry>> errors = actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .ToList();

            List<IDictionary<string, string>> errorParsed = new List<IDictionary<string, string>>();
            foreach (KeyValuePair<string, ModelStateEntry> error in errors)
            {
                Validation errorData = new Validation
                {
                    Key = error.Key,
                    Value = error.Value.Errors.First().ErrorMessage
                };

                errorParsed.Add(errorData.ConvertToDictionary());
            }

            return errorParsed;
        }
    }
}