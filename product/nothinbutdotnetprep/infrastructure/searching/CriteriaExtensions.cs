namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

    }
}