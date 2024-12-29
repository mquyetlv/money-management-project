using money_management_service.Core.Enums;

namespace money_management_service.Core
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }

    public class BaseEntity : BaseEntity<int> { }
}
