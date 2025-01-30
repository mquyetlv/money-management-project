using money_management_service.Core;

namespace money_management_service.DTOs.Transaction
{
    public class TransactionDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
