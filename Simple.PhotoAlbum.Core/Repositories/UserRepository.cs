using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core.Repositories {
   public class UserRepository : IUserRepository {
      private readonly IDataRepository _dataRepository;

      public UserRepository(IDataRepository dataRepository) {
         _dataRepository = dataRepository;
      }

      public IEnumerable<AlbumModel> GetAlbumsForUser(int userid)
         => _dataRepository.GetSet<AlbumModel>()
               .Where(x => x.UserId == userid)
               .ToList();

      public IEnumerable<PhotoModel> GetPhotosForUser(int userid)
         => _dataRepository.GetSet<AlbumModel>()
               .Join(_dataRepository.GetSet<PhotoModel>(),
                     left => left.Id,
                     right => right.AlbumId,
                     (Album, Photo) => new { Album, Photo })
               .Where(x => x.Album.UserId == userid)
               .Select(x => x.Photo)
               .ToList();

      #region
      public void Dispose() {
      }
      #endregion
   }
}
