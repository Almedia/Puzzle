using Microsoft.EntityFrameworkCore;
using Puzzle.Infrastructure.Data.Model;

namespace Puzzle.Infrastructure.Data.Context
{
    public class PhotoContext:DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> options): base(options)
        {
            
        }

        public DbSet<Photo> Photo{get;set;}


    }
}