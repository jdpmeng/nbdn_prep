using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousCriteria<T> : Criteria<T>
    {
        Predicate<T> criteria;

        public AnonymousCriteria(Predicate<T> criteria)
        {
            this.criteria = criteria;
        }

        public bool matches(T item)
        {
            return criteria(item);
        }
    }
}