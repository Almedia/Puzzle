using Puzzle.Infrastructure.Context;
using Puzzle.Infrastructure.Model;
using Puzzle.Core.Interface;
using Puzzle.Core.Model;

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

            return new List<Puzzle.Core.Model.Photo>();
        }
    }
}
