namespace SkillBridge.Application.Dtos.Common
{
    public class PagedResults<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalOfItems { get; set; }

        public long TotalOfPages { get; set; }

        public List<T> Data { get; set; }
    }
}
