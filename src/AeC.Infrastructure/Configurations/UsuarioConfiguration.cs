using AeC.Domain.Entities; using Microsoft.EntityFrameworkCore; using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AeC.Infrastructure.Configurations;
public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>{ public void Configure(EntityTypeBuilder<Usuario> b){ b.ToTable("Usuarios"); b.HasKey(x=>x.Id); b.Property(x=>x.Nome).HasMaxLength(150).IsRequired(); b.Property(x=>x.Login).HasColumnName("Usuario").HasMaxLength(100).IsRequired(); b.Property(x=>x.Senha).HasMaxLength(255).IsRequired(); b.HasIndex(x=>x.Login).IsUnique(); } }
