using Puzzle.Core.Model;

namespace Puzzle.Core.Interface
{
    public interface IUserRepository
    {
         void CreateCustomer(Puzzle.Core.Model.User user);

         User Get(long userId);
    }
}