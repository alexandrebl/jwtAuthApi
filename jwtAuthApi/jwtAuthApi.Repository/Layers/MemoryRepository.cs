using jwtAuthApi.Domain.Entities.Base;
using jwtAuthApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace jwtAuthApi.Repository.Layers
{
    public sealed class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        private static readonly IEnumerable<T> MemoryData = new List<T>();

        public T GetByKey(string searchKey)
        {
            var item = MemoryData.FirstOrDefault(f => f.SearchKey == searchKey);

            return item;
        }
    }
}