using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Common.Utils
{
    public interface IQueryHelper<T>
    {
        ISortHelper<T> Sort { get; }
        IFilterHelper<T> Filter { get; }
    }
}
