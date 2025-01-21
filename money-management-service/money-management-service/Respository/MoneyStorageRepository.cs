using money_management_service.Data;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;

namespace money_management_service.Respository
{
    public class MoneyStorageRepository : BaseRepository<MoneyStorage>, IMoneyStorageRepository
    {
        public MoneyStorageRepository(MoneyManagementDBContext dbContext) : base(dbContext) 
        { }
    }
}
