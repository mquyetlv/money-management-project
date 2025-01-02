using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;

namespace money_management_service.Respository.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<List<ExpenseTypeDTO>> GetAllAsync(SearchExpenseTypeDTO searchCondition);

        Task<ExpenseTypeDTO> GetAsync(int id);

        Task<bool> CreateAsync(ExpenseType entity);

        Task<bool> UpdateAsync(ExpenseType entity);

        Task<bool> DeleteAsync(int id);
    }
}
