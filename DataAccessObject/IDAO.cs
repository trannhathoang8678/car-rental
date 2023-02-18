

using System.Collections.Generic;

namespace DataAccessObject
{
    internal interface IDAO<T>
    {
        public IEnumerable<T> GetList();
        public T GetById(string id);
        public void Add(T t);
        public void Update(T t);
        public void Delete(T t);
    }
}
