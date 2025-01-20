using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IExpenseTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse<ExpenseTypeDTO>> Create(CreateExpenseTypeDTO createDto)
        {
            ExpenseType expenseType = new ExpenseType()
            {
                Name = createDto.Name,
                Description = createDto.Description,
                IsBalanceChanged = createDto.IsBalanceChanged,
            };

            var result = await _repository.CreateAsync(expenseType);
            ExpenseTypeDTO expenseTypeDTO = _mapper.Map<ExpenseTypeDTO>(expenseType);
            return new APIResponse<ExpenseTypeDTO>(expenseTypeDTO);
        }


        public Task<APIResponse<ExpenseTypeDTO>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<List<ExpenseTypeDTO>>> GetAllAsync(QueryModel<ExpenseType> queryModel)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<ExpenseTypeDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<ExpenseTypeDTO>> Update(int id, ExpenseTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
