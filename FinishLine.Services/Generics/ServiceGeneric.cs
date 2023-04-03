using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace FinishLine.Services.Generics;

public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
{
    public T Add(T obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(T obj)
    {
        throw new NotImplementedException();
    }

    public T Get(Expression<Func<T, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return new List<T> { };
    }

    public T Patch(JsonPatchDocument<T> tPatch, Guid id)
    {
        throw new NotImplementedException();
    }

    public T Update(T obj)
    {
        throw new NotImplementedException();
    }
}

