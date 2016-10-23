using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Core.Interface;
using System.Collections.Generic;
using Puzzle.Core.Model;
using Puzzle.Infrastructure.Services;

namespace Puzzle.ApplicationServices
{
    public class PhotoService :IPhotoService   
    {
        private readonly IPhotoRepository photoRepository;
        public PhotoService(IPhotoRepository photoRepository){
            this.photoRepository=photoRepository;
        }

        public void SavePicture(){

        }

        public List<Photo> GetUserPhoto(long userId){
            var photoInfo=this.photoRepository.GetUserPhoto(userId);
            return photoInfo;
        }

    }
}
