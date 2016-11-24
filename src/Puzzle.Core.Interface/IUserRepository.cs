using Puzzle.Core.Model;

namespace Puzzle.Core.Interface
{
    public interface IUserRepository
    {
         void Create(Puzzle.Core.Model.User user);

         User Get(long userId);
    }
}