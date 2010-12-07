 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetprep.infrastructure.searching;
 using Rhino.Mocks;

namespace nothinbutdotnetprep.specs
{   
    public class NotCriteriaSpecs
    {
        public abstract class concern : Observes<Criteria<int>,
                                            NotCriteria<int>>
        {
        
        }

        [Subject(typeof(NotCriteria<>))]
        public class when_matching_an_item : concern
        {
            Establish c = () =>
            {
                original = the_dependency<Criteria<int>>();
                original.Stub(x => x.matches(23)).Return(true);
            };

            Because b = () =>
                result = sut.matches(23);


            It should_negate_the_original = () =>
                result.ShouldBeFalse();


            static bool result;
            static Criteria<int> original;
        }
    }
}
