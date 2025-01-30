using money_management_service.Core;

namespace money_management_service.DTOs.TransactionType
{
    public class TransactionTypeDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ExpenseTypeId { get; set; }

        public string ExpenseTypeName { get; set; }
    }
}
