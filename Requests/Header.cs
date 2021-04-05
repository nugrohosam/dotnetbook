using Microsoft.AspNetCore.Mvc;

namespace BookApi.Requests
{
    public class Header
    {
        [FromHeader(Name = "Authorization")]
        public string Authorization { get; set; }

        [FromHeader(Name = "Locale")]
        public string Locale { get; set; }

        [FromHeader(Name = "Platform")]
        public string Platform { get; set; }
    }
}