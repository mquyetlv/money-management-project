namespace money_management_service.DTOs.TransactionType
{
    public class SearchTransactionTypeDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; } 

        public int? ExpenseTypeId { get; set; }
    }
}
