using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.Entities;

namespace money_management_service.Services.Interfaces
{
    public interface IMoneyStorageService
    {
        Task<APIResponse<List<MoneyStorageDTO>>> GetAllAsync(QueryModel<MoneyStorage> queryModel);
        Task<APIResponse<MoneyStorageDTO>> GetById(int id);
        Task<APIResponse<MoneyStorageDTO>> Create(CreateMoneyStorageDTO entity);
        Task<APIResponse<MoneyStorageDTO>> Update(int id, CreateMoneyStorageDTO entity);
        Task<bool> Delete(int id);
    }
}
