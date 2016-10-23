using Microsoft.EntityFrameworkCore;
using Puzzle.Infrastructure.Model;

namespace Puzzle.Infrastructure.Context
{
    public class PhotoContext:DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> options): base(options)
        {
            
        }

        public DbSet<Photo> Photo{get;set;}


    }
}