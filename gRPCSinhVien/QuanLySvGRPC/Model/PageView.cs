using System.Security.Policy;

namespace QuanLySvGRPC.Model
{
    public class PageView<T>
    {
        public List<T> Data { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }
}
