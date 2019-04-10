using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.PhotoAlbum.Core;
using Simple.PhotoAlbum.Core.Models;

namespace Simple.PhotoAlbum.Web.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class AlbumController : ControllerBase {
      private readonly IDataRepository _dataRepository;
      private readonly IUserRepository _userRepository;

      public AlbumController(IDataRepository dataRepository, IUserRepository userRepository) {
         _dataRepository = dataRepository;
         _userRepository = userRepository;
      }

      // GET api/album
      [HttpGet]
      public ActionResult<IEnumerable<AlbumModel>> Get()
         => _dataRepository.GetSet<AlbumModel>().ToList();

      // GET api/album/id
      [HttpGet("{id}")]
      public ActionResult<AlbumModel> GetById(int id)
         => _dataRepository.GetSet<AlbumModel>().FirstOrDefault(x => x.Id == id);

      // GET api/album/foruser/id
      [HttpGet("forUser/{id}")]
      public ActionResult<IEnumerable<AlbumModel>> GetForUserId(int id)
         => _userRepository.GetAlbumsForUser(id)?.ToList();
   }
}
