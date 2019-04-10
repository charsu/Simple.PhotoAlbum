using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.PhotoAlbum.Core {
   public class AppConfig : IConfig {
      public string DataAlbumsFullPath { get; set; }
      public string DataPhotosFullPath { get; set; }
   }
}
