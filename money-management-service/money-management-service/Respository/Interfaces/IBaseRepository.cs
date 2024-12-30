namespace money_management_service.Respository.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int id);

        public Task<T> Create();

        public Task<T> Update();

        public Task<bool> Delete();
    }
}
