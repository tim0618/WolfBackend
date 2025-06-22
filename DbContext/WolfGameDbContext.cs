using Microsoft.EntityFrameworkCore;
using WolfGame.Model;

namespace WolfGame.Context;
public class WolfGameDbContext : DbContext
{
    public WolfGameDbContext(DbContextOptions<WolfGameDbContext> options) : base(options) { }

    public DbSet<UserModel> User { get; set; }
}

