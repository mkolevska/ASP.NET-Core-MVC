using Microsoft.EntityFrameworkCore;
using TransactionApp.Models;

namespace TransactionApp.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
