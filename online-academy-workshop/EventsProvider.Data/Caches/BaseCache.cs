using EventsProvider.Data;
using EventsProvider.Data.Repository;
using EventsProvider.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data
{
    public abstract class BaseCache<T, K> : ICache<T, K> where T : IIdentifiable<K>
    {
        private const int defaultUpdateIntervalInMilliSeconds = 1000;
        private readonly ConcurrentDictionary<K, T> cache;
        private readonly IRepository<T,K> repository;

        protected BaseCache(IRepository<T, K> repository)
        {
            this.cache = new ConcurrentDictionary<K, T>();
            this.repository = repository;
            this.Init();
            this.InitUpdateThread();
        }

        public T this[K index]
        {
            get
            {
                return this.cache[index];
            }
        }


        public IEnumerable<T> All()
        {
            return this.cache.Values.AsEnumerable();
        }

        protected virtual int UpdateInterval
        {
            get
            {
                return defaultUpdateIntervalInMilliSeconds;
            }
        }

        protected void Add(T element)
        {
             this.cache.TryAdd(element.Id, element);
        }

        protected void Update(T newValue)
        {
            T currentValue;
            this.cache.TryGetValue(newValue.Id, out currentValue);
            this.cache.TryUpdate(newValue.Id, newValue, currentValue);
        }

        private  void Init()
        {
            foreach (var entity in repository.Get())
            {
                this.Add(entity);
            }
        }

        private void UpdateCache()
        {
            foreach (var entity in repository.Get())
            {
                this.Update(entity);
            }
        }

        private void InitUpdateThread()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    this.UpdateCache();
                    await Task.Delay(this.UpdateInterval);
                }
            });
        }
    }
}
