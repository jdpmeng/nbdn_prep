using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public interface SortedCriteria<Item>
    {
        IList<Item> is_sorted(Item item);
    }
}
