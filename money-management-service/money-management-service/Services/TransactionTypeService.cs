using AutoMapper;
using money_management_service.Core;
using money_management_service.DTOs.TransactionType;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly ITransactionTypeRepository _repository;
        private readonly IMapper _mapper;

        public TransactionTypeService(ITransactionTypeRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse<List<TransactionTypeDTO>>> GetAllAsync(QueryModel<TransactionType> queryModel)
        {
            APIResponse<List<TransactionType>> dataResponse = await _repository.GetAllAsync(queryModel);
            return new APIResponse<List<TransactionTypeDTO>>(_mapper.Map<List<TransactionTypeDTO>>(dataResponse.Data), dataResponse.Pagination);
        }

        public async Task<APIResponse<TransactionTypeDTO>> GetById(int id)
        {
            TransactionType transactionType = await _repository.GetAsync(id);
            return new APIResponse<TransactionTypeDTO>(_mapper.Map<TransactionTypeDTO>(transactionType));
        }

        public async Task<APIResponse<TransactionTypeDTO>> Create(CreateTransactionTypeDTO entity)
        {
            TransactionType transactionType = new TransactionType()
            {
                Name = entity.Name,
                Description = entity.Description,
                ExpenseTypeId = entity.ExpenseTypeId,
            };
            await _repository.CreateAsync(transactionType);
            return new APIResponse<TransactionTypeDTO>(_mapper.Map<TransactionTypeDTO>(transactionType));
        }

        public async Task<APIResponse<TransactionTypeDTO>> Update(int id, CreateTransactionTypeDTO entity)
        {
            TransactionType transactionType = await _repository.GetAsync(id);
            if (transactionType == null)
            {
                return null;
            }

            transactionType.Name = entity.Name;
            transactionType.Description = entity.Description;
            transactionType.ExpenseTypeId = entity.ExpenseTypeId;
            await _repository.UpdateAsync(transactionType);
            TransactionTypeDTO transactionTypeDTO = _mapper.Map<TransactionTypeDTO>(transactionType);
            return new APIResponse<TransactionTypeDTO>(transactionTypeDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
