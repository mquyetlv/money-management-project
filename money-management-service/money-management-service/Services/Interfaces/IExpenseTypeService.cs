using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;

namespace money_management_service.Services.Interfaces
{
    public interface IExpenseTypeService
    {
        Task<APIResponse<List<ExpenseTypeDTO>>> GetAllAsync(QueryModel<ExpenseType> queryModel);
        Task<APIResponse<ExpenseTypeDTO>> GetById(int id);
        Task<APIResponse<ExpenseTypeDTO>> Create(CreateExpenseTypeDTO entity);
        Task<APIResponse<ExpenseTypeDTO>> Update(int id, CreateExpenseTypeDTO entity);
        Task<bool> Delete(int id);
    }
}
