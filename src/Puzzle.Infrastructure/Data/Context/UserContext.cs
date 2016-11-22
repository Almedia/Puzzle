using Microsoft.EntityFrameworkCore;
using Puzzle.Infrastructure.Data.Model;

namespace Puzzle.Infrastructure.Data.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
            
        }

        public DbSet<User> User{get;set;}
    }
}