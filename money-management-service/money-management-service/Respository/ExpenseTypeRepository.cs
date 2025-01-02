using money_management_service.Data;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Respository.Interfaces;

namespace money_management_service.Respository
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly MoneyManagementDBContext _dbContext;
        public ExpenseTypeRepository(MoneyManagementDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public Task<bool> CreateAsync(ExpenseTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpenseTypeDTO>> GetAllAsync(SearchExpenseTypeDTO searchCondition)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseTypeDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ExpenseTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
