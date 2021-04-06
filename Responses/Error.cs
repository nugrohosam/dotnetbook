
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookApi.Responses
{
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
                IDictionary<string, string> data = new Dictionary<string, string>();
                data.Add("key", error.Key.ToLower());
                data.Add("field", error.Value.Errors.First().ErrorMessage);

                errorParsed.Add(data);
            }

            return errorParsed;
        }
    }
}