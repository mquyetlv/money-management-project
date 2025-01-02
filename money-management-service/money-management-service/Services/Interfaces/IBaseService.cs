namespace money_management_service.Services.Interfaces
{

    public interface IBaseService<TDto, TKey>
    {
        Task<TDto> GetById(TKey id);
        Task<TDto> Create(TDto entity);
        Task<TDto> Update(TKey id, TDto entity);
        Task Delete(TKey id);
    }

    public interface IBaseService<TDto> : IBaseService<TDto, int> { }
}
