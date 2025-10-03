using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class RoadmapAssessmentConfig : IEntityTypeConfiguration<RoadmapAssessments>
{
    public void Configure(EntityTypeBuilder<RoadmapAssessments> builder)
    {
        builder.ToTable("roadmapassessment");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Roadmap)
            .WithMany(r => r.RoadmapAssessment)
            .OnDelete(DeleteBehavior.Restrict);
    }
}