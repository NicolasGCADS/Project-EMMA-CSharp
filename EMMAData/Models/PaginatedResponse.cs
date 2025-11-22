using System.Collections.Generic;

namespace EMMAData.Models
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IDictionary<string, string>? Links { get; set; }
    }
}
