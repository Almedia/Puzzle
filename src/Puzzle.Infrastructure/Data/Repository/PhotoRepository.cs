using System;
using System.Collections.Generic;
using Puzzle.Infrastructure.Data.Context;
using Puzzle.Infrastructure.Data.Model;
using Puzzle.Core.Interface;
using System.Linq;
 
namespace Puzzle.Infrastructure.Data.Repository
{
    public class PhotoRepository:IPhotoRepository
    {
        private PhotoContext photoContext;
        public PhotoRepository(PhotoContext photoContext){
             this.photoContext=photoContext ;
             this.photoContext.Database.EnsureCreated();
        }

        public void SaveUserPhoto(Puzzle.Core.Model.Photo photo){

                    Photo dbPhoto=new Photo(){
                        UserId=photo.UserId,
                        StorageId="1234",
                        CreateDate=DateTime.Now
                    };
                            
                photoContext.Add(dbPhoto);
                photoContext.SaveChanges();       
        }

        public List<Puzzle.Core.Model.Photo> GetUserPhoto(long userId){
            var list=new List<Puzzle.Core.Model.Photo>();
            var photos=this.photoContext.Photo.Where(x=>x.UserId==userId).ToList();

            foreach (var photo in photos)
            {
                Puzzle.Core.Model.Photo model=new Puzzle.Core.Model.Photo(){
                    UserId=photo.UserId
                };
                list.Add(model);
            }
            return list;
        }
    }
}
