using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter,PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }
    }

    public class CriteriaFactory<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter,PropertyType> property_accessor;

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
    }
}