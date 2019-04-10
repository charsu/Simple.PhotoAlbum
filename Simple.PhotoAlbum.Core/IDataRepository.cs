using System;
using System.Linq;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core {
   public interface IDataRepository {
      IQueryable<T> GetSet<T>() where T : IModel;
   }
}
