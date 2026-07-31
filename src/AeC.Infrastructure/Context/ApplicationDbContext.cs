using AeC.Domain.Entities; using Microsoft.EntityFrameworkCore;
namespace AeC.Infrastructure.Context;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{ public DbSet<Usuario> Usuarios => Set<Usuario>(); public DbSet<Endereco> Enderecos => Set<Endereco>(); protected override void OnModelCreating(ModelBuilder modelBuilder)=> modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); }
