using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core {
   public class DataRepositoryInMemory : IDataRepository {
      private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<int, IModel>> _storage = new ConcurrentDictionary<Type, ConcurrentDictionary<int, IModel>>();

      public IQueryable<T> GetSet<T>() where T : IModel
         => GetStorage<T>().Values.Cast<T>().AsQueryable();

      public void AddSet<T>(List<T> items) where T : IModel {
         var storage = GetStorage<T>();
         items?.ForEach(item => storage.TryAdd(item.Id, item));
      }

      private ConcurrentDictionary<int, IModel> GetStorage<T>()
         => _storage.GetOrAdd(typeof(T), new ConcurrentDictionary<int, IModel>());
   }
}
