using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puzzle.ApplicationServices;
using Microsoft.Extensions.Logging;

namespace Puzzle.WebApi.Controllers
{
    [Route("api/puzzle/photo")]
    public class PhotoController:Controller
    {
        private readonly ILogger<PhotoController> _logger;

        public PhotoController(ILogger<PhotoController> logger){
            this._logger=logger;
        }

        [HttpPost]
        public IActionResult Post(Image image){
            this._logger.LogInformation("Listing all items");

            return CreatedAtRoute("GetTodo", new { id = image.CreateDate }, image);           
        }
    }
}