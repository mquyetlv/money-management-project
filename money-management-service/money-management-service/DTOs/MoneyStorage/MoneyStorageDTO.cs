using money_management_service.Core;
using money_management_service.Enums;

namespace money_management_service.DTOs.MoneyStorage
{
    public class MoneyStorageDTO : BaseDTO
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public string CardNumber { get; set; }

        public string OwnerName { get; set; }

        public CardType CardType { get; set; }

        public string CardTypeName { get; set; }
    }
}
