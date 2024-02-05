using Microsoft.EntityFrameworkCore;

namespace Souq.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }
    }
}
