using AutoMapper;
using money_management_service.Core;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class BaseService<TEntity, TDto, TKey> : IBaseService<TDto, TKey> where TEntity : BaseEntity<TKey> where TDto : BaseDTO<TKey>
    {
        private readonly IBaseRepository<TEntity, TKey> _repo;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity, TKey> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TDto> Create(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            await _repo.CreateAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task Delete(TKey id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<TDto>> GetAll()
        {
            List<TEntity> entities = await _repo.GetAllAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> GetById(TKey id)
        {
            TEntity entity = await _repo.GetAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Update(TKey id, TDto dto)
        {
            TEntity entity = await _repo.GetAsync(id);
            TEntity entityUpdate = _mapper.Map<TEntity>(dto);
            _mapper.Map(entityUpdate, entity);
            await _repo.UpdateAsync(entity);
            return _mapper.Map<TDto>(entity);
        }
    }

    public class BaseService<TEntity, TDto> : BaseService<TEntity, TDto, int> where TEntity : BaseEntity where TDto : BaseDTO
    {
        public BaseService(IBaseRepository<TEntity> _repo, IMapper _mapper) : base(_repo, _mapper) { }
    }
}
