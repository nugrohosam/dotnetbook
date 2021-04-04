using Microsoft.AspNetCore.Mvc;

namespace BookApi.Requests
{
    public class Header
    {
        [FromHeader(Name = "Authorization")]
        public string authorization { get; set; }

        [FromHeader(Name = "Locale")]
        public string locale { get; set; }

        [FromHeader(Name = "Platform")]
        public string platform { get; set; }
    }
}