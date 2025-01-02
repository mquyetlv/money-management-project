using money_management_service.DTOs.ExpenseType;

namespace money_management_service.Services.Interfaces
{
    public interface IExpenseTypeService
    {
        Task<List<ExpenseTypeDTO>> GetAll();
        Task<ExpenseTypeDTO> GetById(int id);
        Task<ExpenseTypeDTO> Create(ExpenseTypeDTO expenseTypeDTO);
        Task<ExpenseTypeDTO> Update(int id, ExpenseTypeDTO entity);
        Task Delete(int id);
    }
}
