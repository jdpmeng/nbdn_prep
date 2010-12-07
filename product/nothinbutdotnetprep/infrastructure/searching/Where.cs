using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ElementToFind>
    {
        public static Func<ElementToFind, PropertyType> has_a<PropertyType>(
            Func<ElementToFind, PropertyType> property_accessor)
        {
            return property_accessor;
        }
    }
}