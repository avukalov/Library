using Library.Models.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Library.Models.Utilities
{
    public class FilterHelper<T, K> : IFilterHelper<T, K>
    {
        //Todo
        public IQueryable<T> ApplyFilters(IQueryable<T> entities, K filterQueryParams)
        {
            if (!entities.Any())
            {
                return entities;
            }

            var propertyInfos = typeof(K).GetProperties();

            var filterQueryBuilder = new StringBuilder();

            foreach (var property in propertyInfos)
            {
                if (property.Name.Equals("PageNumber") || property.Name.Equals("PageSize")){ continue; }

                var propertyValue = property.GetValue(filterQueryParams);

                if (string.IsNullOrEmpty((string)propertyValue)) { continue; }

                if (property.Name.Contains("min", StringComparison.InvariantCultureIgnoreCase))
                {
                    filterQueryBuilder.Append($"{property.Name} >= {propertyValue} AND ");
                }
                if (property.Name.Contains("max", StringComparison.InvariantCultureIgnoreCase))
                {
                    filterQueryBuilder.Append($"{property.Name} <= {propertyValue} AND ");
                }
                
                filterQueryBuilder.Append($"{property.Name} == {propertyValue} AND ");

            }

            var filterQuery = filterQueryBuilder.ToString().TrimEnd(' ', 'A', 'N', 'D', ' ');

            return entities.Where(filterQuery);
        }

        
    }
}
