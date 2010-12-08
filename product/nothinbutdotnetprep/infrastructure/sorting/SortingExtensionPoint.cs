using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public interface SortingExtensionPoint<ItemToSort,PropertyType>
    {
        Criteria<ItemToSort> create_for(Criteria<PropertyType> real_criteria);
    }
}
