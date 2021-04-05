using Microsoft.AspNetCore.Mvc;

namespace BookApi.Requests
{
    public class Query
    {
        [FromQuery(Name = "search")]
        public string Search { get; set; }

        [FromQuery(Name = "pagination")]
        public bool pagination { get; set; }

        [FromQuery(Name = "page")]
        public int Page { get; set; }

        [FromQuery(Name = "limit")]
        public int Limit { get; set; }
    }
}