using money_management_service.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace money_management_service.Entities
{
    [Table("InvestmentHistory")]
    public class InvestmentHistory : BaseEntity
    {
        public int TransactionId { get; set; }

        [ForeignKey("TransactionId")]
        public Transaction Transaciton { get; set; }

        public int InvestmentPortfolioId {  get; set; }

        [ForeignKey("InvestmentPortfolioId")]
        public InvestmentPortfolio InvestmentPortfolio { get; set; }
    }
}
