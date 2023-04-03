using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace FinishLine.Services.Generics;

public interface IServiceGeneric<T> where T : class
{
    List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    T Get(Expression<Func<T, bool>>? predicate = null);
    T Add(T obj);
    T Update(T obj);
    void Delete(T obj);
    T Patch(JsonPatchDocument<T> tPatch, Guid id);
}

