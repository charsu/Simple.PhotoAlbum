﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Simple.PhotoAlbum.Web.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class AlbumController : ControllerBase {
      // GET api/values
      [HttpGet]
      public ActionResult<IEnumerable<string>> Get() {
         return new string[] { "value1", "value2" };
      }
   }
}