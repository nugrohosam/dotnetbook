using Microsoft.AspNetCore.Mvc;

namespace BookApi.Requests
{
    public class Query
    {
        [FromQuery(Name = "search")]
        public string Search { get; set; }

        [FromQuery(Name = "pagination")]
        public bool Pagination { get; set; }

        [FromQuery(Name = "per_page")]
        public int PerPage { get; set; }

        [FromQuery(Name = "page")]
        public int Page { get; set; }
    }
}