using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProj.Common
{
    public class PagedList<T> : List<T>, IPagedList<T>, IEnumerable<T>, IPagedList, IEnumerable
    {
        public PagedList(IEnumerable<T> allItems, int pageIndex, int pageSize);
        public PagedList(IQueryable<T> allItems, int pageIndex, int pageSize);
        public PagedList(IEnumerable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount);
        public PagedList(IQueryable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount);

        public int CurrentPageIndex { get; set; }
        public int EndRecordIndex { get; }
        public int PageSize { get; set; }
        public int StartRecordIndex { get; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; }
    }
}