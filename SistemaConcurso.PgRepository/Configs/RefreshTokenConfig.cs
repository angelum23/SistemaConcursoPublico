using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshTokens>
{
    public void Configure(EntityTypeBuilder<RefreshTokens> builder)
    {
        builder.ToTable("refreshtokens");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.TokenHash).IsRequired().HasMaxLength(255);
        builder.HasIndex(x => x.TokenHash).IsUnique();
        
        builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Expires).IsRequired();
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.ReplacedByTokenHash).HasMaxLength(256);
        
        builder.Ignore(x => x.IsActive);
    }
}