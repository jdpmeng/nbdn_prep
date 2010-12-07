using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<ItemToFilter,PropertyType> : Criteria<ItemToFilter>
    {
        Func<ItemToFilter, PropertyType> accessor;
        Criteria<PropertyType> real_criteria;

        public PropertyCriteria(Func<ItemToFilter, PropertyType> accessor, Criteria<PropertyType> real_criteria)
        {
            this.accessor = accessor;
            this.real_criteria = real_criteria;
        }

        public bool matches(ItemToFilter item)
        {
            return real_criteria.matches(accessor(item));
        }
    }
}