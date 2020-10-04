using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> items, int currentPage, int totalCount, int pageSize)
        {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int count = source.Count();
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, pageNumber, count, pageSize);
        }


        public static object GenPaginationMetadata(PagedList<T> values)
        {
            return new {
                values.TotalCount,
                values.PageSize,
                values.CurrentPage,
                values.TotalPages,
                values.HasNext,
                values.HasPrevious
            };
        }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
