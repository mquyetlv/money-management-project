using money_management_service.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    [Table("ExpenseType")]
    public class ExpenseType : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsBalanceChanged { get; set; }

        public List<TransactionType> TransactionTypes { get; set; }
    }
}
