using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;

namespace Mod.Entity
{
    public class EntitiesManager<TKey, TValue> where TValue : DataInfo
    {
        private readonly Dictionary<TKey, TValue> _entities = new();

        public bool Is(TKey key)
        {
            return _entities.ContainsKey(key);
        }

        public Dictionary<TKey, TValue> Get()
        {
            return _entities;
        }

        public TValue Get(TKey entity)
        {
            return _entities.GetValueOrDefault(entity);
        }

        public KeyValuePair<TKey, TValue> Get(int id)
        {
            return _entities.FirstOrDefault(data => data.Value.Id == id);
        }

        public bool Add(TKey entity, TValue data)
        {
            return _entities.TryAdd(entity, data);
        }

        public bool Remove(TKey entity)
        {
            return _entities.Remove(entity);
        }
    }
}