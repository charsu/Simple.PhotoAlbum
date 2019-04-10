using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Core {
   public class Setup {
      public static void LoadStaticData(IConfig config) {
         using (var service = new DataRepositoryInMemory()) {
            if (!string.IsNullOrEmpty(config.DataAlbumsFullPath)) {
               service.AddSet(
                  JsonConvert.DeserializeObject<List<AlbumModel>>(
                     File.ReadAllText(config.DataAlbumsFullPath)));
            }
            if (!string.IsNullOrEmpty(config.DataPhotosFullPath)) {
               service.AddSet(
                  JsonConvert.DeserializeObject<List<PhotoModel>>(
                     File.ReadAllText(config.DataPhotosFullPath)));
            }
         }
      }
   }
}
