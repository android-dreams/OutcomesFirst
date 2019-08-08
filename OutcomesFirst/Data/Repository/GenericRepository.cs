using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace OutcomesFirst.Repository
{
    public class GenericRepository<T> :  ICRUDRepository<T> where T : class
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public GenericRepository()
        {
        }
        

     
        //// Async Methods
        //public virtual async Task<int?> InsertAsync(T entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("null entity");
        //    return await _connection.InsertAsync(entity, _transaction);
        //}

        //public virtual async Task<int> UpdateAsync(T entity)
        //{
        //    return await _connection.UpdateAsync(entity, _transaction);
        //}

        //public virtual async Task<int> DeleteAsync(int id)
        //{
        //    return await _connection.DeleteAsync(id, _transaction);
        //}

        //public virtual async Task<int> DeleteListAsync(object where)
        //{
        //    return await _connection.DeleteListAsync<T>(where, _transaction);
        //}
        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    T item = await _connection.GetAsync<T>(id);
        //    return item;
        //}

        //public virtual async Task<IEnumerable<T>> FindAllAsync(object where = null)
        //{
        //    return await _connection.GetListAsync<T>(whereConditions: where ?? new { });
        //}

        //public virtual async Task<IEnumerable<T>> FindAllAsync(string cond)
        //{
        //    return await _connection.GetListAsync<T>(conditions: cond);
        //}
    }
}
