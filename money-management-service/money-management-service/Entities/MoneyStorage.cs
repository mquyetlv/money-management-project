using money_management_service.Core;
using money_management_service.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    [Table("MoneyStorage")]
    public class MoneyStorage : BaseEntity
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public string CardNumber { get; set; }

        public string OwnerName { get; set; }

        public CardType CardType { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
