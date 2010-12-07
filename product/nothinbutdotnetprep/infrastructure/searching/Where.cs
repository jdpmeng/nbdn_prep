using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }

    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return
                new AnonymousCriteria<ItemToFilter>(x => new List<PropertyType>(values).Contains(property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> greater_than<ComparablePropertyType>(ComparablePropertyType value) where ComparablePropertyType : PropertyType, IComparable
        {
            return new AnonymousCriteria<ItemToFilter>(x => (value.CompareTo(property_accessor(x)) < 0 ? true : false));
        }

        public Criteria<ItemToFilter> between<ComparablePropertyType>(ComparablePropertyType startValue, ComparablePropertyType endValue) where ComparablePropertyType : PropertyType, IComparable
        {
            return new AnonymousCriteria<ItemToFilter>(x => ((startValue.CompareTo(property_accessor(x)) <= 0 && endValue.CompareTo(property_accessor(x)) >= 0) ? true : false));
        }

    }
}