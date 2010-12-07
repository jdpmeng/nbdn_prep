namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        Criteria<ItemToFilter> create_for(Criteria<PropertyType> real_criteria);
    }
}