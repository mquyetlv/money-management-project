using money_management_service.Core.Enums;

namespace money_management_service.Core
{
    public class BaseDTO<TKey>
    {
        public TKey Id { get; set; }

        public string StatusName { get; set; }

        public Status Status { get; set; }
    }

    public class BaseDTO : BaseDTO<int> { }
}
