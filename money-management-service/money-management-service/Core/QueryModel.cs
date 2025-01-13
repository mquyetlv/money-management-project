using System.Linq.Expressions;

namespace money_management_service.Core
{
    public class QueryModel<T> : BaseSearchCondition
    {
        public List<Expression<Func<T, bool>>> Filters { get; set; } = new();

        public List<Expression<Func<T, object>>> Includes { get; set; } = new();

        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; }

        public bool Tracking { get; set; } = false;
    }
}
