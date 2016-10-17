using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puzzle.ApplicationServices;
using Microsoft.Extensions.Logging;
using Puzzle.Core.Interface;

namespace Puzzle.WebApi.Controllers
{
    [Route("api/puzzle/photo")]
    public class PhotoController:Controller
    {
        // private readonly ILogger<PhotoController> _logger;

        private readonly IPicture pictureService;

        public PhotoController(IPicture pictureService){
        this.pictureService=pictureService;
             
        }

        [HttpPost]
        public IActionResult Post(Image image){

            return CreatedAtRoute("GetTodo", new { id = image.CreateDate }, image);           
        }
    }
}