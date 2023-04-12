using Microsoft.EntityFrameworkCore;
using Training.Backend.Data.Entities;

namespace Training.Backend.Data.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
}