using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Puzzle.Core.Interface;
using Puzzle.Core.Model;
using Puzzle.Infrastructure.Services;

namespace Puzzle.WebApi.Controllers
{
    [Route("api/puzzle/photo")]
    public class PhotoController:Controller
    {
        // private readonly ILogger<PhotoController> _logger;

        private readonly IPhotoService photoService;

        public PhotoController(IPhotoService photoService){
            this.photoService=photoService;
             
        }

        [HttpPost("{id}", Name = "user")]
        public IActionResult Post([FromBody]Photo photo){

            this.photoService.SaveUserPhoto(photo);

            return CreatedAtRoute("user", new { id = photo.UserId }, photo);           
        }

        [HttpGet]
        public List<Photo> GetPictureDetails(long customerId){

            var customerPhoto=this.photoService.GetUserPhoto(customerId);
            return customerPhoto;
        }
    }
}