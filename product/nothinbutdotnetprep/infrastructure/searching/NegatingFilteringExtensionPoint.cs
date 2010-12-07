namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingFilteringExtensionPoint<ItemToFilter, PropertyType> : FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        FilteringExtensionPoint<ItemToFilter, PropertyType> original;

        public NegatingFilteringExtensionPoint(FilteringExtensionPoint<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> create_for(Criteria<PropertyType> real_criteria)
        {
            return new NotCriteria<ItemToFilter>(original.create_for(real_criteria));
        }
    }
}