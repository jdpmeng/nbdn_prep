using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class DefaultSortingExtensionPoint<ItemToSort, PropertyType> :
        SortingExtensionPoint<ItemToSort,PropertyType>
    {
        Func<ItemToSort, PropertyType> accessor { get; set; }

        public SortedCriteria<ItemToSort> create_for(SortedCriteria<PropertyType> real_criteria)
        {
            return new PropertyCriteria<ItemToSort, PropertyType>(accessor, real_criteria);
        }

        public DefaultSortingExtensionPoint(Func<ItemToSort, PropertyType> property_accessor)
        {
            this.accessor = property_accessor;
        }
    

    }
}
