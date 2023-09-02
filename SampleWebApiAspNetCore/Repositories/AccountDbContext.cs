using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Entities;

namespace WebApiAspNetCore.Repositories
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }
        public DbSet<AccountEntity> Account { get; set; } = null!;
    }
}
