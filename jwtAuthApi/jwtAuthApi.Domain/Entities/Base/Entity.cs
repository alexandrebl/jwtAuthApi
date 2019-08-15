using System;
using System.Collections.Generic;
using System.Text;

namespace jwtAuthApi.Domain.Entities.Base
{
    public abstract class Entity
    {
        protected Entity(){}

        protected Entity(string searchKey)
        {
            SearchKey = searchKey;
        }

        public virtual string SearchKey { get; }
    }
}
