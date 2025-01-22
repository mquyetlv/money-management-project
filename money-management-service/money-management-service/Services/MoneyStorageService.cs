using AutoMapper;
using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class MoneyStorageService : IMoneyStorageService
    {
        private readonly IMapper _mapper;
        private readonly IMoneyStorageRepository _repository;
        public MoneyStorageService(IMapper mapper, IMoneyStorageRepository repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<APIResponse<MoneyStorageDTO>> Create(CreateMoneyStorageDTO entity)
        {
            MoneyStorage moneyStorage = new MoneyStorage()
            {
                Name = entity.Name,
                Balance = entity.Balance,
                CardNumber = entity.CardNumber,
                OwnerName = entity.OwnerName,
                CardType = entity.CardType,
            };

            var result = await _repository.CreateAsync(moneyStorage);
            MoneyStorageDTO moneyStoreageDto = _mapper.Map<MoneyStorageDTO>(moneyStorage);
            return new APIResponse<MoneyStorageDTO>(moneyStoreageDto);
        }

        public Task<bool> Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<APIResponse<List<MoneyStorageDTO>>> GetAllAsync(QueryModel<MoneyStorage> queryModel)
        {
            APIResponse<List<MoneyStorage>> data = await _repository.GetAllAsync(queryModel);
            return new APIResponse<List<MoneyStorageDTO>>(_mapper.Map<List<MoneyStorageDTO>>(data.Data), data.Pagination);
        }

        public async Task<APIResponse<MoneyStorageDTO>> GetById(int id)
        {
            MoneyStorage moneyStorage = await _repository.GetAsync(id);
            MoneyStorageDTO moneyStorageDTO = _mapper.Map<MoneyStorageDTO>(moneyStorage);
            return new APIResponse<MoneyStorageDTO>(moneyStorageDTO);
        }

        public async Task<APIResponse<MoneyStorageDTO>> Update(int id, CreateMoneyStorageDTO entity)
        {
            MoneyStorage moneyStorage = await _repository.GetAsync(id);
            if (moneyStorage != null) 
            {
                moneyStorage.Name = entity.Name;
                moneyStorage.Balance = entity.Balance;
                moneyStorage.CardNumber = entity.CardNumber;
                moneyStorage.CardType = entity.CardType;
                moneyStorage.OwnerName = entity.OwnerName;

                await _repository.UpdateAsync(moneyStorage);
                MoneyStorageDTO moneyStorageDTO = _mapper.Map<MoneyStorageDTO>(moneyStorage);
                return new APIResponse<MoneyStorageDTO>(moneyStorageDTO);
            }
            return null;   
        }
    }
}
