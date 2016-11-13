using System.Collections.Generic;
using Puzzle.Core.Model;

namespace Puzzle.Core.Interface
{
    public interface IPhotoRepository
    {

       List<Puzzle.Core.Model.Photo> GetUserPhoto(long userId);

       void SaveUserPhoto(Puzzle.Core.Model.Photo photo);
    }
}