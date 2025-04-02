using money_management_service.Core;
using money_management_service.DTOs.Transaction;
using money_management_service.Entities;

namespace money_management_service.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<APIResponse<List<TransactionDTO>>> GetAllAsync(QueryModel<Transaction> queryModel);
        Task<APIResponse<TransactionDTO>> GetById(int id);
        Task<APIResponse<TransactionDTO>> Create(CreateTransactionDTO entity);
        Task<APIResponse<TransactionDTO>> Update(int id, CreateTransactionDTO entity);
        Task<bool> Delete(int id);
    }
}
