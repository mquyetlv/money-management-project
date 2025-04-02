using money_management_service.Core;

namespace money_management_service.DTOs.Transaction
{
    public class TransactionDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public int TransactionTypeId { get; set; }

        public string TransactionTypeName { get; set; }

        public int MoneyStorageId { get; set; }

        public string MoneyStorageName { get; set; }
    }
}
