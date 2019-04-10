using System;
using System.Collections.Generic;
using System.Linq;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core {
   public interface IDataRepository: IDisposable {
      IQueryable<T> GetSet<T>() where T : IModel;
      void AddSet<T>(List<T> items) where T : IModel;
   }
}
