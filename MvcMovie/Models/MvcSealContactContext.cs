using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcSealContactContext : DbContext
    {
        public MvcSealContactContext (DbContextOptions<MvcSealContactContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.SealContact> SealContact { get; set; }
    }
}