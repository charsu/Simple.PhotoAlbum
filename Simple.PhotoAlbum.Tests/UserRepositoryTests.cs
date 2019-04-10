using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Extras.Moq;
using NUnit.Framework;
using Simple.PhotoAlbum.Core;
using Simple.PhotoAlbum.Core.Models;
using Simple.PhotoAlbum.Core.Repositories;

namespace Simple.PhotoAlbum.Tests {
   public class UserRepositoryTests {
      private AutoMock GetMock()
         => AutoMock.GetLoose()
               // we setup 2 photso to belong to one album
               .SetUserRepository<PhotoModel>(
                  Enumerable.Range(1, 20).Select(x => new PhotoModel {
                     Id = x,
                     AlbumId = x % 2
                  }).ToList())
               // 10 albums for 5 users  
               .SetUserRepository<AlbumModel>(
                  Enumerable.Range(1, 10).Select(x => new AlbumModel {
                     Id = x,
                     UserId = x % 2
                  }).ToList());

      [Test]
      public void UserRepository_GetAlbums_OK() {
         var userid = 1;

         var service = GetMock().Create<UserRepository>();
         var output = service.GetAlbumsForUser(userid)?.ToList();

         Assert.AreEqual(5, output.Count);
      }

      [Test]
      public void UserRepository_GetPhotos_OK() {
         var userid = 1;

         var service = GetMock().Create<UserRepository>();
         var output = service.GetPhotosForUser(userid)?.ToList();

         Assert.AreEqual(10, output.Count);
      }
   }

   internal static class Helpers {
      public static AutoMock SetUserRepository<T>(this AutoMock mock, List<T> data = null)
         where T : IModel {
         var m = mock.Mock<IDataRepository>();
         m.Setup(a => a.GetSet<T>())
            .Returns(data?.AsQueryable());
         return mock;
      }
   }
}
