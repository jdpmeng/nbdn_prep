using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public NotDefaultCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NotDefaultCriteriaFactory<ItemToFilter, PropertyType>(this); }
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return create_for(new IsEqualToAny<PropertyType>(values));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> create_for(Criteria<PropertyType> real_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor,
                                                                    real_criteria); 
        }
    }

    public class NotDefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        private readonly CriteriaFactory<ItemToFilter, PropertyType> _factory;

        public NotDefaultCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> factory)
        {
            _factory = factory;
        }

        public Criteria<ItemToFilter>  equal_to(PropertyType value_to_equal)
        {
            return _factory.not_equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter>  equal_to_any(params PropertyType[] values)
        {
 	        throw new NotImplementedException();
        }

        public Criteria<ItemToFilter>  not_equal_to(PropertyType value_to_equal)
        {
 	        throw new NotImplementedException();
        }

        public Criteria<ItemToFilter>  create_for(Criteria<PropertyType> real_criteria)
        {
 	        throw new NotImplementedException();
        }
    }


}