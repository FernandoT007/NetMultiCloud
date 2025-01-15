using Microsoft.EntityFrameworkCore;
using sedes_function_app.Models;

namespace sedes_function_app.Persistence;
public class SedeDbContext : DbContext
{
    public SedeDbContext(DbContextOptions<SedeDbContext> options) : base(options) { }

    public DbSet<Sede>? Sedes { get; set; }
};
