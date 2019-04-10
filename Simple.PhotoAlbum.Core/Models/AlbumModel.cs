using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.PhotoAlbum.Core.Models {
   public class AlbumModel : IModel {
      public int Id { get; set; }
      public int UserId { get; set; }
      public string Title { get; set; }
   }
}
