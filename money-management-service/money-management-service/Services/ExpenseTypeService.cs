using AutoMapper;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IMapper mapper, IExpenseTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ExpenseTypeDTO> Create(ExpenseTypeDTO expenseTypeDTO)
        {
            return await _repository.CreateAsync(expenseTypeDTO);
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
