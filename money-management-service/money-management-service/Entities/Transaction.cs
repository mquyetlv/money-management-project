using money_management_service.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    public class Transaction : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int amount { get; set; }

        public int TransactionTypeId { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        public int MoneyStorageId { get; set; }

        [ForeignKey("MoneyStorageId")]
        public MoneyStorage MoneyStorage { get; set; }
    }
}
