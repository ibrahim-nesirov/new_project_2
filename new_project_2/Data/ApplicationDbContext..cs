using Microsoft.EntityFrameworkCore;
using new_project_2.Models;

namespace new_project_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Musteri> Musteriler { get; set; }
    }
}
