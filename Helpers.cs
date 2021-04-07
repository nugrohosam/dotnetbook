using System.Net;
using System.Collections.Generic;
using BookApi.Responses;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace BookApi
{
    public class Utility
    {
        public static List<IDictionary<string, string>> CreateSingleValidation(string key, string field)
        {
            IDictionary<string, string> validation = new Dictionary<string, string>();
            validation.Add("key", key);
            validation.Add("field", field);

            List<IDictionary<string, string>> validations = new List<IDictionary<string, string>>();
            validations.Add(validation);

            return validations;
        }
        public static List<IDictionary<string, string>> CreateValidation(string key, string field)
        {
            IDictionary<string, string> validation = new Dictionary<string, string>();
            validation.Add("key", key);
            validation.Add("field", field);

            List<IDictionary<string, string>> validations = new List<IDictionary<string, string>>();
            validations.Add(validation);

            return validations;
        }
    }
    [DataContract]
    public abstract class ApiResponse
    {
        [DataMember]
        public string version { get { return "1.0.0"; } }
    }
    public class ApiResponseData : ApiResponse
    {
        [DataMember]
        public int status_code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object data { get; set; }
        public ApiResponseData(HttpStatusCode statusCode, object data = null)
        {
            this.status_code = (int)statusCode;
            this.data = data;
        }
    }
    public class ApiResponseDataList : ApiResponse
    {
        [DataMember]
        public int status_code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int count { get; set; }
        public ApiResponseDataList(HttpStatusCode statusCode, object items, int count)
        {
            this.status_code = (int)statusCode;
            this.items = items;
            this.count = count;
        }
    }
    public class ApiResponsePagination : ApiResponse
    {
        [DataMember]
        public int status_code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int per_page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int total { get; set; }
        public ApiResponsePagination(HttpStatusCode statusCode, PaginationModel paginationModel)
        {
            this.status_code = (int)statusCode;
            this.items = paginationModel.Data;
            this.page = paginationModel.Page;
            this.per_page = paginationModel.PerPage;
            this.total = paginationModel.Total;
        }
    }
    public class ApiResponseError : ApiResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string error_message { get; set; }

        [DataMember]
        public int status_code { get; set; }
        public ApiResponseError(HttpStatusCode statusCode, string errorMessage)
        {
            this.status_code = (int)statusCode;
            this.error_message = errorMessage;
        }
    }
    public class ApiResponseValidationError : ApiResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public object errors { get; set; }

        [DataMember]
        public int status_code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string error_message { get; set; }
        public ApiResponseValidationError(HttpStatusCode statusCode, object errors, string errorMessage = "Validation Message")
        {
            this.status_code = (int)statusCode;
            this.errors = errors;
            this.error_message = errorMessage;
        }
    }

}