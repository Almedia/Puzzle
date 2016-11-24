using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Puzzle.Core.Model;
using Puzzle.Infrastructure.Services;

namespace Puzzle.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController:Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService){
            this.userService=userService;
        }

        [HttpGet("{id}")]
         public IEnumerable<string> Get(long userId){
             this.userService.Get(userId);
            // this.photoRepository.Save("me");
            return new string[] { "value1", "value2" };
        }

        [HttpPost]   
        public IActionResult Create([FromBody]User user){
                this.userService.Create(user);
                return CreatedAtRoute("user", new { id = user.UserID }, user);           
            }

        [HttpPut]
        public IActionResult Put([FromBody]User user){

                // this.photoService.SaveUserPhoto(photo);

                return CreatedAtRoute("user", new { id = user.UserID }, user);                       
            }   
        [HttpGet(Name="create")]
        public void Login(){

        }
    }
}
