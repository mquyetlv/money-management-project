using money_management_service.Core;

namespace money_management_service.Services.Interfaces
{

    public interface IBaseService<TEntity, TDto, TKey>
    {
        Task<List<TDto>> GetAllAsync(QueryModel<TEntity> queryModel);
        Task<TDto> GetById(TKey id);
        Task<TDto> Create(TDto entity);
        Task<TDto> Update(TKey id, TDto entity);
        Task Delete(TKey id);
    }

    public interface IBaseService<TEntity, TDto> : IBaseService<TEntity, TDto, int> { }
}
