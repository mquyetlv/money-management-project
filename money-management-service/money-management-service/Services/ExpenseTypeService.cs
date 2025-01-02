using money_management_service.Data;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly MoneyManagementDBContext _dbContext;
        private readonly IExpenseTypeRepository _repository;

        public ExpenseTypeService(MoneyManagementDBContext dbContext, IExpenseTypeRepository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public Task<ExpenseTypeDTO> Create(ExpenseTypeDTO expenseTypeDTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpenseTypeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseTypeDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseTypeDTO> Update(int id, ExpenseTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
