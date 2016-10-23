using System.Collections.Generic;
using Puzzle.Core.Model;

namespace Puzzle.Core.Interface
{
    public interface IPhotoRepository
    {
       void Save(string me);

       List<Puzzle.Core.Model.Photo> GetUserPhoto(long userId);
    }
}