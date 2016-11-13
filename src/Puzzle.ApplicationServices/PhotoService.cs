using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Core.Interface;
using Puzzle.Core.Model;
using Puzzle.Infrastructure.Services;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Puzzle.ApplicationServices  
{
    public class PhotoService :IPhotoService   
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IAmazonS3 s3Client;

        public PhotoService(IPhotoRepository photoRepository,IAmazonS3 s3Client){
            this.photoRepository=photoRepository;
            this.s3Client=s3Client;
        }

        public void SaveUserPhoto(Photo photo){

                this.photoRepository.SaveUserPhoto(photo);
                PutAmazonService(photo);
                
        }

        public List<Photo> GetUserPhoto(long userId){
            var photoInfo=this.photoRepository.GetUserPhoto(userId);
            return photoInfo;
        }

        private void PutAmazonService(Photo photo){
                PutObjectRequest putRequest2 = new PutObjectRequest
                {
                    BucketName = "",
                    Key = "",
                    FilePath = "",
                    ContentType = "text/plain"
                };
                s3Client.PutObjectAsync(putRequest2);
        }

    }
}
