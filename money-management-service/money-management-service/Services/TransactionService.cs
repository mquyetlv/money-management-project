using AutoMapper;
using money_management_service.Core;
using money_management_service.DTOs.Transaction;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse<List<TransactionDTO>>> GetAllAsync(QueryModel<Transaction> queryModel)
        {
            APIResponse<List<Transaction>> dataResponse = await _repository.GetAllAsync(queryModel);
            return new APIResponse<List<TransactionDTO>>(_mapper.Map<List<TransactionDTO>>(dataResponse.Data), dataResponse.Pagination);
        }

        public async Task<APIResponse<TransactionDTO>> GetById(int id)
        {
            Transaction transaction = await _repository.GetAsync(id);
            return new APIResponse<TransactionDTO>(_mapper.Map<TransactionDTO>(transaction));
        }

        public async Task<APIResponse<TransactionDTO>> Create(CreateTransactionDTO entity)
        {
            Transaction transaction = new Transaction()
            {
                Name = entity.Name,
                Description = entity.Description,
                Amount = entity.Amount,
                TransactionTypeId = entity.TransactionTypeId,
                MoneyStorageId = entity.MoneyStorageId,
            };
            await _repository.CreateAsync(transaction);
            return new APIResponse<TransactionDTO>(_mapper.Map<TransactionDTO>(transaction));
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<APIResponse<TransactionDTO>> Update(int id, CreateTransactionDTO createTransactionDto)
        {
            Transaction transaction = await _repository.GetAsync(id);
            if (transaction == null)
            {
                return null;
            }

            transaction.Name = createTransactionDto.Name;
            transaction.Description = createTransactionDto.Description;
            transaction.Amount = createTransactionDto.Amount;
            transaction.TransactionTypeId = createTransactionDto.TransactionTypeId;
            transaction.MoneyStorageId = createTransactionDto.MoneyStorageId;
            await _repository.UpdateAsync(transaction);
            TransactionDTO transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            return new APIResponse<TransactionDTO>(transactionDTO);
        }
    }
}
