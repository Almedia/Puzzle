using System.Collections.Generic;
using Puzzle.Core.Model;

namespace Puzzle.Infrastructure.Services
{
    public interface IUserService
    {
          User Get(long userId);
    }
}