using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class ModuleAssessmentConfig : IEntityTypeConfiguration<ModuleAssessment>
{
    public void Configure(EntityTypeBuilder<ModuleAssessment> builder)
    {
        builder.ToTable("moduleassessment");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Module)
            .WithMany(m => m.ModuleAssessment)
            .HasForeignKey(x => x.IdModule)
            .OnDelete(DeleteBehavior.Restrict);
    }
}