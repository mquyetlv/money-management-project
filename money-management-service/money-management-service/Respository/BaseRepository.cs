using Microsoft.EntityFrameworkCore;
using money_management_service.Core;
using money_management_service.Data;
using money_management_service.Respository.Interfaces;
using System.Linq.Expressions;

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

        public async Task<APIResponse<List<TEntity>>> GetAllAsync(QueryModel<TEntity> queryModel)
        {
            IQueryable<TEntity> query = GetQueryable(queryModel);
            List<TEntity> entities = await query.ToListAsync();
            int total = await _dbSet.CountAsync();
            Pagination pagination = new Pagination(total, queryModel.Page, queryModel.Size);
            return new APIResponse<List<TEntity>>(entities, pagination);
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            _dbcontext.Add(entity);
            return await SaveChange();
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            if (entity == null) 
            { 
                return false;
            }

            _dbSet.Remove(entity);
            return await SaveChange();
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

        private IQueryable<TEntity> GetQueryable(QueryModel<TEntity> queryModel)
        {
            IQueryable<TEntity> query = _dbSet;

            if (queryModel == null)
                return query;

            if (!queryModel.Tracking)
            {
                query = query.AsNoTracking();
            }

            foreach (Expression<Func<TEntity, object>> includeProp in queryModel.Includes)
            {
                query = query.Include(includeProp);
            }

            foreach (Expression<Func<TEntity, bool>> filterCondition in queryModel.Filters)
            {
                query = query.Where(filterCondition);
            }

            if (queryModel.OrderBy != null)
            {
                query = queryModel.OrderBy(query);
            }

            query = query.Skip(queryModel.Page * queryModel.Size).Take(queryModel.Size);
            return query;
        }
    }

    public class BaseRepository<TEntity> : BaseRepository<TEntity, int> where TEntity : BaseEntity
    {
        public BaseRepository(MoneyManagementDBContext dbcontext) : base(dbcontext)
        {
        }
    }
}
