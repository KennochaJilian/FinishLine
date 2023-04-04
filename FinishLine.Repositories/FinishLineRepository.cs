using FinishLine.Models;
using FinishLine.Models.Interfaces;
using FinishLine.Repositories.Generics;

namespace FinishLine.Repositories
{
    public class FinishLineRepository <T> : RepositoryGeneric<T> where T : class, IIncludeObject, new()
    {
        public FinishLineRepository(FinishLineDbContext context) : base(context)
        {
        }
    }
}
