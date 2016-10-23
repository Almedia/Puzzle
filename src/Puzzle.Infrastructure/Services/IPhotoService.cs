using System.Collections.Generic;
using Puzzle.Core.Model;

namespace Puzzle.Infrastructure.Services
{
    public interface IPhotoService
    {
        void SavePicture();

        List<Photo> GetCustomerPhoto(long customerId);
    }
}