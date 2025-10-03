using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class ModuleConfig : IEntityTypeConfiguration<Modules>
{
    public void Configure(EntityTypeBuilder<Modules> builder)
    {
        builder.ToTable("modules");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Roadmap)
            .WithMany(r => r.Modules)
            .OnDelete(DeleteBehavior.Cascade);
    }
}