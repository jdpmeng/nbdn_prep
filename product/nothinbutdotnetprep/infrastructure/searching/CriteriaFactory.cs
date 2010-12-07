namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] values);
        Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> create_for(Criteria<PropertyType> real_criteria);
    }
}