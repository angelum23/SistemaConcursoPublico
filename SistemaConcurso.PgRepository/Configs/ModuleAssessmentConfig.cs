using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class ModuleAssessmentConfig : IEntityTypeConfiguration<ModuleAssessments>
{
    public void Configure(EntityTypeBuilder<ModuleAssessments> builder)
    {
        builder.ToTable("moduleassessment");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Module)
            .WithMany(m => m.ModuleAssessment)
            .OnDelete(DeleteBehavior.Restrict);
    }
}