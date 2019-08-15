using jwtAuthApi.Domain.Entities.Base;

namespace jwtAuthApi.Repository.Interfaces
{
    public interface IRepository<out T> where T : Entity
    {
        T GetByKey(string searchKey);
    }
}