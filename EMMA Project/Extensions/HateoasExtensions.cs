using System.Collections.Generic;

namespace EMMA_Project.Extensions
{
    public static class HateoasExtensions
    {
        public static IDictionary<string, string> BuildPagingLinks(string baseUrl, int pageNumber, int pageSize, int totalPages)
        {
            var links = new Dictionary<string, string>
            {
                ["self"] = $"{baseUrl}?pageNumber={pageNumber}&pageSize={pageSize}",
                ["first"] = $"{baseUrl}?pageNumber=1&pageSize={pageSize}",
                ["last"] = $"{baseUrl}?pageNumber={totalPages}&pageSize={pageSize}"
            };

            if (pageNumber > 1)
                links["prev"] = $"{baseUrl}?pageNumber={pageNumber - 1}&pageSize={pageSize}";

            if (pageNumber < totalPages)
                links["next"] = $"{baseUrl}?pageNumber={pageNumber + 1}&pageSize={pageSize}";

            return links;
        }
    }
}
