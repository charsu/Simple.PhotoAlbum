using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Simple.PhotoAlbum.Core;

namespace Simple.PhotoAlbum.Tests {
   public class Setup {
      public const string Integration = "Integration";

      public static void OnStart() {
         var dir = TestContext.CurrentContext.TestDirectory;

         // setup the data repository by loading the static data from json
         // we dont plan to alter the data so it is safe to only do it once
         Simple.PhotoAlbum.Core.Setup.LoadStaticData(new AppConfig() {
            DataAlbumsFullPath = Path.Combine(dir, @"..\..\..\..\albums.json"),
            DataPhotosFullPath = Path.Combine(dir, @"..\..\..\..\photos.json")
         });
      }
   }
}
