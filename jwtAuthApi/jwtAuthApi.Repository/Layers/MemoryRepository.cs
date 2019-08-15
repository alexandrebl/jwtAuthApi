using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jwtAuthApi.Domain.Entities.Base;
using jwtAuthApi.Repository.Interfaces;

namespace jwtAuthApi.Repository.Layers
{
    public sealed class MemoryRepository<T>: IRepository<T> where T: Entity
    {
        private static readonly IEnumerable<T> MemoryData = new List<T>();

        public T GetByKey(string searchKey)
        {
            var item = MemoryData.FirstOrDefault(f => f.SearchKey == searchKey);

            return item;
        }
    }
}
