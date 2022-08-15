using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Data;
public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
}
