namespace money_management_service.DTOs.Transaction
{
    public class CreateTransactionDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public int TransactionTypeId { get; set; }

        public int MoneyStorageId { get; set; }
    }
}
