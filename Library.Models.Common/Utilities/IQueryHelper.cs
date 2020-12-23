using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Common.Utilities
{
    public interface IQueryHelper<T, K>
    {
        ISortHelper<T> Sort { get; }
        IFilterHelper<T, K> Filter { get; }
    }
}
