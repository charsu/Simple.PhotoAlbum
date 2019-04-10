using System;
using System.Collections.Generic;
using System.Text;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core {
   public interface IUserRepository : IDisposable {
      IEnumerable<PhotoModel> GetPhotosForUser(int userid);
      IEnumerable<AlbumModel> GetAlbumsForUser(int userid);
   }
}
