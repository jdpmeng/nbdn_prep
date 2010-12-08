using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortedPropertyCriteria<ItemToSort,PropertyType> : SortedCriteria<ItemToSort>
    {
        Func<ItemToSort, PropertyType> accessor;
        SortedCriteria<PropertyType> real_criteria;

        public SortedPropertyCriteria(Func<ItemToSort, PropertyType> accessor, SortedCriteria<PropertyType> real_criteria)
        {
            this.accessor = accessor;
            this.real_criteria = real_criteria;
        }

        public IList<ItemToSort> is_sorted(PropertyType pType)
        {
            return real_criteria.is_sorted(pType);
        }
    
    }
}
