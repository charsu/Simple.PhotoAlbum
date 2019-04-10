using System.IO;
using System.Linq;
using Autofac.Extras.Moq;
using NUnit.Framework;
using Simple.PhotoAlbum.Core;
using Simple.PhotoAlbum.Core.Models;

namespace Tests {
   public class DataRespositoryTests {
      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [SetUp]
      public void OnStart() {
         Simple.PhotoAlbum.Tests.Setup.OnStart();
      }

      [Test]
      public void DataRespository_Query_Photos() {
         var service = GetMock().Create<DataRepositoryInMemory>();

         var output = service.GetSet<PhotoModel>()
            .Where(x => x.AlbumId == 1).ToList();

         Assert.IsTrue(output != null && output.Count > 0);
      }

      [Test]
      public void DataRespository_Query_Albums() {
         var service = GetMock().Create<DataRepositoryInMemory>();

         var output = service.GetSet<AlbumModel>()
            .Where(x => x.UserId == 1).ToList();

         Assert.IsTrue(output != null && output.Count > 0);
      }
   }
}