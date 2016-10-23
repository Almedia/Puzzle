using System.Collections.Generic;
using Puzzle.Infrastructure.Context;
using Puzzle.Infrastructure.Model;
using Puzzle.Core.Interface;
using System.Linq;

namespace Puzzle.Infrastructure.Repository
{
    public class PhotoRepository:IPhotoRepository
    {
        private PhotoContext photoContext;
        public PhotoRepository(PhotoContext photoContext){
             this.photoContext=photoContext ;
             this.photoContext.Database.EnsureCreated();
        }

         public void Save(string me){
                    Photo photo=new Photo(){
                    CustomerID=123
                    };
                            
                photoContext.Add(photo);
                photoContext.SaveChanges();       
        }

        public List<Puzzle.Core.Model.Photo> GetUserPhoto(long userId){
            var list=new List<Puzzle.Core.Model.Photo>();
            var photos=this.photoContext.Photo.Where(x=>x.CustomerID==userId).ToList();

            foreach (var photo in photos)
            {
                Puzzle.Core.Model.Photo model=new Puzzle.Core.Model.Photo(){
                    CustomerId=photo.CustomerID
                };
                list.Add(model);
            }
            return list;
        }
    }
}
