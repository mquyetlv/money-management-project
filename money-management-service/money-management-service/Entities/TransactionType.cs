using money_management_service.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    [Table("TransactionType")]
    public class TransactionType : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public ExpenseType ExpenseType { get; set; } 

        public List<Transaction> Transactions { get; set; }
    }
}
