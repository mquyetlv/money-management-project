using money_management_service.Data;
using money_management_service.Entities;

namespace money_management_service.Respository
{
    public class TransactionTypeRepository : BaseRepository<TransactionType>
    {
        public TransactionTypeRepository(MoneyManagementDBContext dbContext) : base(dbContext) { }
    }
}
