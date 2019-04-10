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
   public class PhotosController : ControllerBase {
      private readonly IDataRepository _dataRepository;
      private readonly IUserRepository _userRepository;

      public PhotosController(IDataRepository dataRepository, IUserRepository userRepository) {
         _dataRepository = dataRepository;
         _userRepository = userRepository;
      }

      // GET api/album
      [HttpGet]
      public ActionResult<IEnumerable<PhotoModel>> Get()
         => _dataRepository.GetSet<PhotoModel>().ToList();

      // GET api/album/id
      [HttpGet("{id}")]
      public ActionResult<PhotoModel> GetById(int id)
         => _dataRepository.GetSet<PhotoModel>().FirstOrDefault(x => x.Id == id);

      // GET api/photo/foruser/id
      [HttpGet("forUser/{id}")]
      public ActionResult<IEnumerable<PhotoModel>> GetForUserId(int id)
         => _userRepository.GetPhotosForUser(id)?.ToList();

   }
}
