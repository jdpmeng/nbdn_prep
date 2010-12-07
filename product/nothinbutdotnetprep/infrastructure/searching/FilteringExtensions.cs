using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,
            PropertyType value_to_equal)
        {
            return equal_to_any(extension_point, value_to_equal);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,
            params PropertyType[] values)
        {
            return create_for(extension_point,
                              new IsEqualToAny<PropertyType>(values));
        }


        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType start,PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_for(extension_point, new FallsInRange<PropertyType>(
                                  new InclusiveRange<PropertyType>(start,end)));

        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_for(extension_point, new FallsInRange<PropertyType>(
                                  new RangeWithNoUpperBound<PropertyType>(value)));

        }


        static Criteria<ItemToFilter> create_for<ItemToFilter,PropertyType>(FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,Criteria<PropertyType> real_criteria)
        {
            return extension_point.create_for(real_criteria);
        }
    }
}