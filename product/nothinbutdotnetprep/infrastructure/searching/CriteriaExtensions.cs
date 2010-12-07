using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this Func<ItemToFilter, PropertyType> property_accessor, PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }
    }
}