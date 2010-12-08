using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Order<ItemToSort> where ItemToSort : IComparable<ItemToSort>
    {
        public static DefaultSortingExtensionPoint<ItemToSort,PropertyType> sort_descending<PropertyType>(Func<ItemToSort,PropertyType> property_accessor)
        {
            return new DefaultSortingExtensionPoint<ItemToSort,PropertyType>(property_accessor);
        }
    }
}
