using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Models.Common.Utilities
{
    public interface IFilterHelper<T, K>
    {
        IQueryable<T> ApplyFilters(IQueryable<T> entities, K filterQueryParams);
    }
}
