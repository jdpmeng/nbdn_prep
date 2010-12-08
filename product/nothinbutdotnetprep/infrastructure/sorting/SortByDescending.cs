using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortByDescending<T> : SortedCriteria<T> where T : IComparable<T>
    {
        private IList<T> items;

        public SortByDescending(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> is_sorted(T )
    }
}
