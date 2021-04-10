using System.Net;
using System.Collections.Generic;
using BookApi.Responses;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookApi
{
    public class ErrorUtility
    {
        public static List<IDictionary<string, string>> CreateSingleErrorValidation(string key, string field)
        {
            IDictionary<string, string> errorsValidation = ErrorUtility.SetErrorValidation(key, field);
            List<IDictionary<string, string>> validations = new List<IDictionary<string, string>>();
            validations.Add(errorsValidation);

            return validations;
        }
        public static IDictionary<string, string> SetErrorValidation(string key, string field)
        {
            IDictionary<string, string> validation = new Dictionary<string, string>();
            validation.Add("key", key);
            validation.Add("field", field);
            return validation;
        }
    }
    [DataContract]
    public abstract class ApiResponse
    {
        [DataMember]
        public string Version { get { return "1.0.0"; } }
    }
    public class ApiResponseData : ApiResponse
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Data { get; set; }
        public ApiResponseData(HttpStatusCode statusCode, object data = null)
        {
            this.StatusCode = (int)statusCode;
            this.Data = data;
        }
    }
    public class ApiResponseDataList : ApiResponse
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Count { get; set; }
        public ApiResponseDataList(HttpStatusCode statusCode, object items, int count)
        {
            this.StatusCode = (int)statusCode;
            this.Items = items;
            this.Count = count;
        }
    }
    public class ApiResponsePagination : ApiResponse
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int PerPage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int total { get; set; }
        public ApiResponsePagination(HttpStatusCode statusCode, PaginationModel paginationModel)
        {
            this.StatusCode = (int)statusCode;
            this.items = paginationModel.Data;
            this.Page = paginationModel.Page;
            this.PerPage = paginationModel.PerPage;
            this.total = paginationModel.Total;
        }
    }
    public class ApiResponseError : ApiResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }

        [DataMember]
        public int StatusCode { get; set; }
        public ApiResponseError(HttpStatusCode statusCode, string errorMessage)
        {
            this.StatusCode = (int)statusCode;
            this.ErrorMessage = errorMessage;
        }
    }
    public class ApiResponseValidationError : ApiResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public object Errors { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }
        
        public ApiResponseValidationError(HttpStatusCode statusCode, object errors, string errorMessage = "Validation Message")
        {
            this.StatusCode = (int)statusCode;
            this.Errors = errors;
            this.ErrorMessage = errorMessage;
        }
    }

}