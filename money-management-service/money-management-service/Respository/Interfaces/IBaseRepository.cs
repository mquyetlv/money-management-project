﻿using money_management_service.Core;

namespace money_management_service.Respository.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<APIResponse<List<TEntity>>> GetAllAsync(QueryModel<TEntity> queryModel);

        Task<TEntity> GetAsync(TKey id);

        Task<bool> CreateAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TKey id);
    }

    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, int> where TEntity : BaseEntity { }
}
