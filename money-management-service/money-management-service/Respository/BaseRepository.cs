using Microsoft.EntityFrameworkCore;
using money_management_service.Core;
using money_management_service.Data;
using money_management_service.Respository.Interfaces;

namespace money_management_service.Respository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        protected readonly MoneyManagementDBContext _dbcontext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(MoneyManagementDBContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<TEntity>();
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            _dbcontext.Add(entity);
            return await SaveChange();
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            return await SaveChange();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            List<TEntity> entities = await _dbSet.ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbcontext.Update(entity);
            return await SaveChange();
        }

        private async Task<bool> SaveChange()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }
    }

    public class BaseRepository<TEntity> : BaseRepository<TEntity, int> where TEntity : BaseEntity
    {
        public BaseRepository(MoneyManagementDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
