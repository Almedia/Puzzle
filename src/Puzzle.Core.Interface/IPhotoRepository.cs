using System.Collections.Generic;
using Puzzle.Core.Model;

namespace Puzzle.Core.Interface
{
    public interface IPhotoRepository
    {
       void Save(string me);

       Photo GetUserPhoto(long customerId);
    }
}