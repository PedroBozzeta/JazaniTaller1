﻿
namespace JazaniT1.Domain.Cores
{
    namespace JazaniT1.Domain.Cores.Repositories
    {
        public interface ICrudRepository<T, ID>
        {
            Task<IReadOnlyList<T>> FindAllAsync();
            Task<T?> FindByIdAsync(ID id);
            Task<T?> SaveAsync(T entity);
        }
    }

}
