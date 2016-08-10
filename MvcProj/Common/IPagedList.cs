using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProj.Common
{
    public interface IPagedList : IEnumerable
    {
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
    }

    public interface IPagedList<T> : IEnumerable<T>, IPagedList, IEnumerable
    {
    }
}
