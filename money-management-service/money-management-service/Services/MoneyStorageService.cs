using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class MoneyStorageService : IMoneyStorageService
    {
        public Task<APIResponse<MoneyStorageDTO>> Create(CreateMoneyStorageDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<List<MoneyStorageDTO>>> GetAllAsync(QueryModel<MoneyStorage> queryModel)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<MoneyStorageDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<MoneyStorageDTO>> Update(int id, CreateMoneyStorageDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
