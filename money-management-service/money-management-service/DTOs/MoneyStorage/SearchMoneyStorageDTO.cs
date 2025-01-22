using money_management_service.Enums;

namespace money_management_service.DTOs.MoneyStorage
{
    public class SearchMoneyStorageDTO
    {
        public string? Name { get; set; }

        public string? CardNumber { get; set; }

        public string? OwnerName { get; set; }

        public CardType? CardType { get; set; }
    }
}
