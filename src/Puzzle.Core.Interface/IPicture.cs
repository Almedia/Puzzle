using System.Collections.Generic;

namespace Puzzle.Core.Interface
{
    public interface IPicture
    {
        void SavePicture();

        List<string> GetPicture();
    }
}