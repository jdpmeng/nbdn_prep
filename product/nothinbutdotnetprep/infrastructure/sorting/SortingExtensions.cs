using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SortingExtensions
    {
        public static Criteria<ItemToSort> by_descending<ItemToSort, PropertyType>(
            this SortingExtensionPoint<ItemToSort, PropertyType> extension_point,
            PropertyType value)
        {
            return create_for(extension_point,
                              new SortByDescending<PropertyType>(value));
        }

        static Criteria<ItemToSort> create_for<ItemToSort, PropertyType>(SortingExtensionPoint<ItemToSort, PropertyType> extension_point, Criteria<PropertyType> real_criteria)
        {
            return extension_point.create_for(real_criteria);
        }
    }
}
