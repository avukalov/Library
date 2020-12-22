using Library.Models.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Utils
{
    public class QueryHelper<T> : IQueryHelper<T>
    {
        private ISortHelper<T> _sortHelper;
        private IFilterHelper<T> _filterHelper;

        public ISortHelper<T> Sort
        {
            get
            {
                if (_sortHelper == null)
                {
                    _sortHelper = new SortHelper<T>();
                }

                return _sortHelper;
            }
        }

        public IFilterHelper<T> Filter => throw new NotImplementedException();
    }
}
