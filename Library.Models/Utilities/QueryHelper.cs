using Library.Models.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Utilities
{
    public class QueryHelper<T, K> : IQueryHelper<T, K>
    {
        private ISortHelper<T> _sortHelper;
        private IFilterHelper<T, K> _filterHelper;

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

        public IFilterHelper<T, K> Filter
        {
            get
            {
                if (_filterHelper == null)
                {
                    _filterHelper = new FilterHelper<T, K>();
                }

                return _filterHelper;
            }
        }
    }
}
