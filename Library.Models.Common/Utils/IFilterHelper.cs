using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Models.Common.Utils
{
    public interface IFilterHelper<T>
    {
        IQueryable<T> ApplyFilters(IQueryable<T> entities, string filterQueryParams)
        {
            return entities;
        }
    }
}
