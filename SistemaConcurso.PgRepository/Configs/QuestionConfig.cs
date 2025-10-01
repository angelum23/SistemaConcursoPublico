using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class QuestionConfig : IEntityTypeConfiguration<Questions>
{
    public void Configure(EntityTypeBuilder<Questions> builder)
    {
        builder.ToTable("questions");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.LessonAssessment)
            .WithMany(l => l.Questions)
            .HasForeignKey(x => x.IdLessonAssessment)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.ModuleAssessment)
            .WithMany(m => m.Questions)
            .HasForeignKey(x => x.IdModuleAssessment)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.RoadmapAssessment)
            .WithMany(r => r.Questions)
            .HasForeignKey(x => x.IdRoadmapAssessment)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(x => x.HasCheckConstraint(
            name: "CK_Question_OneParent",
            sql: "((CASE WHEN \"idLessonAssessment\" IS NOT NULL THEN 1 ELSE 0 END) + " +
                 " (CASE WHEN \"idModuleAssessment\" IS NOT NULL THEN 1 ELSE 0 END) + " +
                 " (CASE WHEN \"idRoadmapAssessment\" IS NOT NULL THEN 1 ELSE 0 END)) = 1")
        );
    }
}