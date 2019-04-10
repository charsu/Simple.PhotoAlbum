using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.PhotoAlbum.Core {
   public interface IConfig {
      string DataAlbumsFullPath { get; }
      string DataPhotosFullPath { get; }
   }
}
