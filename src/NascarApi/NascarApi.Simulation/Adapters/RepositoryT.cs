using System.Collections.Generic;
using System.Linq;

namespace NascarApi.Simulation.Adapters
{
    abstract class Repository<T, Key> where T : IKeyedItem<Key>, new()
    {
        protected List<T> _items;

        protected Repository()
        {
            _items = new List<T>();
        }

        protected virtual T Get(Key id)
        {
            return _items.FirstOrDefault(i => i.Id.Equals(id)); ;
        }

        protected virtual IEnumerable<T> GetList()
        {
            return _items.ToList();
        }

        protected virtual T Insert(T item)
        {
            _items.Add(item);

            SaveChanges();

            return item;
        }

        protected virtual T Update(T item)
        {
            var itemToDelete = Get(item.Id);

            if (itemToDelete != null)
                _items.Remove(itemToDelete);

            _items.Add(item);

            SaveChanges();

            return item;
        }

        protected virtual void Delete(T item)
        {
            var itemToDelete = Get(item.Id);

            if (itemToDelete != null)
                _items.Remove(itemToDelete);

            SaveChanges();
        }

        protected virtual Key GetLastId()
        {
            return _items.Max(i => i.Id);
        }

        protected abstract void SaveChanges();

        protected abstract List<T> Load();
    }
}
