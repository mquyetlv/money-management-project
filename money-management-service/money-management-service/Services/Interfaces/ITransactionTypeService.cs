using money_management_service.Core;
using money_management_service.DTOs.TransactionType;
using money_management_service.Entities;

namespace money_management_service.Services.Interfaces
{
    public interface ITransactionTypeService
    {
        Task<APIResponse<List<TransactionTypeDTO>>> GetAllAsync(QueryModel<TransactionType> queryModel);
        Task<APIResponse<TransactionTypeDTO>> GetById(int id);
        Task<APIResponse<TransactionTypeDTO>> Create(CreateTransactionTypeDTO entity);
        Task<APIResponse<TransactionTypeDTO>> Update(int id, CreateTransactionTypeDTO entity);
        Task<bool> Delete(int id);
    }
}
