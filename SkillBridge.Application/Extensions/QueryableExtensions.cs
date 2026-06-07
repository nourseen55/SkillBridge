using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
namespace SkillBridge.Application.Extensions
{
    public class GridResult<T>
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; } = new();
    }

    public static class QueryableExtensions
    {
        public static async Task<GridResult<T>> ToPagedResultAsync<T>(
      this IQueryable<T> query,
         int pageNumber,
        int pageSize,
        string sortColumn,
        string sortDir)
        {
            var totalRecords = await query.CountAsync();

            query = query.OrderBy(
                $"{sortColumn} {sortDir}");


            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new GridResult<T>
            {
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = data
            };
        }
    }
}
