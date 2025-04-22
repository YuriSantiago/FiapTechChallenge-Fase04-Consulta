using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase

    {
        IList<T> GetAll();

        IList<T> GetAll(Func<IQueryable<T>, IQueryable<T>>? include);

        T GetById(int id);

        T GetById(int id, Func<IQueryable<T>, IQueryable<T>> include);

    }
}
