using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetprep.infrastructure.searching;
using Rhino.Mocks;

namespace nothinbutdotnetprep.specs
{
    public class PropertyCriteriaSpecs
    {
        public abstract class concern : Observes<Criteria<OurItem>,
                                            PropertyCriteria<OurItem, int>>
        {
        }

        [Subject(typeof(PropertyCriteria<,>))]
        public class when_matching_an_item : concern
        {
            Establish c = () =>
            {
                my_criteria = the_dependency<Criteria<int>>();
                my_criteria.Stub(x => x.matches(Arg<int>.Is.Anything)).Return(true);
                provide_a_basic_sut_constructor_argument<Func<OurItem,int>>(x => 23);
            };

            Because b = () =>
                result = sut.matches(new OurItem());


            It should_match_if_its_real_criteria_matches = () =>
                result.ShouldBeTrue();


            static bool result;
            static Criteria<int> my_criteria;
        }

        public class OurItem
        {
        }
    }
}