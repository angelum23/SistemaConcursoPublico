using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class RoadmapAssessmentConfig : IEntityTypeConfiguration<RoadmapAssessment>
{
    public void Configure(EntityTypeBuilder<RoadmapAssessment> builder)
    {
        builder.ToTable("roadmapassessment");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Roadmap)
            .WithMany(r => r.RoadmapAssessment)
            .HasForeignKey(x => x.IdRoadmap)
            .OnDelete(DeleteBehavior.Restrict);
    }
}