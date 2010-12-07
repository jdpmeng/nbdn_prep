using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType>  : CriteriaFactory<ItemToFilter,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> original;


        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return original.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal)
        {
            return original.not_equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return create_for(new FallsInRange<PropertyType>(
                                  new RangeWithNoUpperBound<PropertyType>(value)));

        }

        public Criteria<ItemToFilter> between(PropertyType start_value,
                                                                      PropertyType end_value)
        {
            
            return create_for(new FallsInRange<PropertyType>(
                                  new InclusiveRange<PropertyType>(start_value, end_value)));
        }

        public Criteria<ItemToFilter> create_for(Criteria<PropertyType> real_criteria)
        {
            return original.create_for(real_criteria);
        }
    }
}