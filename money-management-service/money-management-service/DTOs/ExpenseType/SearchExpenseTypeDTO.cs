using money_management_service.Core;

namespace money_management_service.DTOs.ExpenseType
{
    public class SearchExpenseTypeDTO : BaseSearchCondition
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool? IsBalanceChanged { get; set; }
    }
}
