using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsEqualToAny<T> : Criteria<T>
    {
        IList<T> items;

        public IsEqualToAny(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool matches(T item)
        {
            return items.Contains(item);
        }
    }
}