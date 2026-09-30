using CatalogoDeJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeJogos.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Jogo> Jogos => Set<Jogo>();
}
