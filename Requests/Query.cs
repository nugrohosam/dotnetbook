using Microsoft.AspNetCore.Mvc;

namespace BookApi.Requests
{
    public class Query
    {
        [FromQuery(Name = "search")]
        public string search { get; set; }

        [FromQuery(Name = "pagination")]
        public bool pagination { get; set; }

        [FromQuery(Name = "page")]
        public int page { get; set; }

        [FromQuery(Name = "limit")]
        public int limit { get; set; }
    }
}