using System.Net;
using System.Collections.Generic;
using BookApi.Responses;
using System.Runtime.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using dotenv.net;
using System.Text;
using System.Linq;
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
    public class AuthUtility
    {
        public static string GenerateJwtToken(string email)
        {
            IDictionary<string, string> env = DotEnv.Read();
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(env["KEY"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static string ValidateJwtToken(string token)
        {
            IDictionary<string, string> env = DotEnv.Read();
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(env["KEY"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string email = jwtToken.Claims.First(x => x.Type == "email").Value;

                return email;
            }
            catch
            {
                return null;
            }
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

        [DataMember(EmitDefaultValue = true)]
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

        [DataMember(EmitDefaultValue = true)]
        public object Items { get; set; }

        [DataMember(EmitDefaultValue = true)]
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

        [DataMember(EmitDefaultValue = true)]
        public object items { get; set; }

        [DataMember(EmitDefaultValue = true)]
        public int Page { get; set; }

        [DataMember(EmitDefaultValue = true)]
        public int PerPage { get; set; }

        [DataMember(EmitDefaultValue = true)]
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
        [DataMember(EmitDefaultValue = true)]
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
        [DataMember(EmitDefaultValue = true)]
        public object Errors { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = true)]
        public string ErrorMessage { get; set; }

        public ApiResponseValidationError(HttpStatusCode statusCode, object errors, string errorMessage = "Validation Message")
        {
            this.StatusCode = (int)statusCode;
            this.Errors = errors;
            this.ErrorMessage = errorMessage;
        }
    }

}