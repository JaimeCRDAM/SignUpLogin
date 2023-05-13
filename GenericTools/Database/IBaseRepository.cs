using GenericTools.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IBaseRepository<T> where T : BaseEntity
{
    // Create
    void Add(T entity);
    Task AddAsync(T entity);

    // Read
    T GetById(int id);
    Task<T> GetByIdAsync(int id);
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    // Update
    void Update(T entity);
    Task UpdateAsync(T entity);

    // Delete
    void Delete(T entity);
    Task DeleteAsync(T entity);
}