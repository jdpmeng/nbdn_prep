using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<Item>
    {
        bool matches(Item item);
    }



}