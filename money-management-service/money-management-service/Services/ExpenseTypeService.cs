using AutoMapper;
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

        public async Task<APIResponse<List<ExpenseTypeDTO>>> GetAllAsync(QueryModel<ExpenseType> queryModel)
        {
            APIResponse<List<ExpenseType>> data = await _repository.GetAllAsync(queryModel);
            return new APIResponse<List<ExpenseTypeDTO>>(_mapper.Map<List<ExpenseTypeDTO>>(data.Data), data.Pagination);
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<APIResponse<ExpenseTypeDTO>> GetById(int id)
        {
            ExpenseType expeseType = await _repository.GetAsync(id);
            if (expeseType != null)
            {
                ExpenseTypeDTO expenseTypeDTO = _mapper.Map<ExpenseTypeDTO>(expeseType);
                return new APIResponse<ExpenseTypeDTO>(expenseTypeDTO);
            }

            return null;    
        }

        public async Task<APIResponse<ExpenseTypeDTO>> Update(int id, CreateExpenseTypeDTO updateDto)
        {
            ExpenseType expenseType = await _repository.GetAsync(id);
            if (expenseType != null)
            {
                expenseType.Name = updateDto.Name;
                expenseType.Description = updateDto.Description;
                expenseType.IsBalanceChanged = updateDto.IsBalanceChanged;

                bool updateSuccess = await _repository.UpdateAsync(expenseType);
                if (updateSuccess)
                {
                    ExpenseTypeDTO expenseTypeDto = _mapper.Map<ExpenseTypeDTO>(expenseType);
                    return new APIResponse<ExpenseTypeDTO>(expenseTypeDto);
                }

                return null;
            }

            return null;
        }
    }
}
