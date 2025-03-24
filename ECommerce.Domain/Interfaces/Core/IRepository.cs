using ECommerce.Domain.Entities.Core;
using System.Linq.Expressions;

namespace ECommerce.Domain.Interfaces.Core;

public interface IRepository<T> where T : Entity
{
    T GetById(int id);
    T Get(Expression<Func<T, bool>> predicate);
    List<T> GetAll(Expression<Func<T, bool>>? predicate, bool asNoTracking);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}