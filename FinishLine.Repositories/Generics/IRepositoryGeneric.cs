using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace FinishLine.Repositories.Generics
{
    public interface IRepositoryGeneric<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>>? predicate = null);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
        T Patch(JsonPatchDocument<T> tPatch, T obj);
    }
}
