using System.Linq;
using Autofac.Extras.Moq;
using NUnit.Framework;
using Simple.PhotoAlbum.Core;
using Simple.PhotoAlbum.Core.Models;

namespace Tests {
   public class Tests {
      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [SetUp]
      public void Setup() {
         // setup the data repository by loading the static data from json
      }

      [Test]
      public void DataRespository_Query_Photos() {
         var service = GetMock().Create<DataRepositoryInMemory>();

         var output = service.GetSet<PhotoModel>()
            .Where(x => x.AlbumId == 1).ToList();

         Assert.IsTrue(output != null && output.Count > 0);
      }
   }
}