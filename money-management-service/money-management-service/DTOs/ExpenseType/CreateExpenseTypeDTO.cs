namespace money_management_service.DTOs.ExpenseType
{
    public class CreateExpenseTypeDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsBalanceChanged { get; set; }
    }
}
