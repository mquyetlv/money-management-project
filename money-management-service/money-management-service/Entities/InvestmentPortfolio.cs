using money_management_service.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    [Table("InvestmentPortfolio")]
    public class InvestmentPortfolio : BaseEntity
    {
        public string Name { get; set; }

        public long CurrentPrice { get; set; }

        public List<InvestmentHistory> InvestmentHistories { get; set; }
    }
}
