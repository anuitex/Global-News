using Repositories.Interfaces;
using Entities;

namespace Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    { }
}
