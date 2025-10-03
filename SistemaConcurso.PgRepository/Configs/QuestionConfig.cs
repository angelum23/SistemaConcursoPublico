using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class QuestionConfig : IEntityTypeConfiguration<Questions>
{
    public void Configure(EntityTypeBuilder<Questions> builder)
    {
        builder.ToTable(name: "questions", buildAction: b =>
        {
            b.HasCheckConstraint(
                name: "CK_Question_OneParent",
                sql: "((CASE WHEN \"idlessonassessment\" IS NOT NULL THEN 1 ELSE 0 END) + " +
                     " (CASE WHEN \"idmoduleassessment\" IS NOT NULL THEN 1 ELSE 0 END) + " +
                     " (CASE WHEN \"idroadmapassessment\" IS NOT NULL THEN 1 ELSE 0 END)) = 1");
        });
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Order).IsRequired();
        builder.Property(x => x.Question).IsRequired().HasColumnType("text");
        builder.Property(x => x.OptionA).IsRequired().HasMaxLength(500);
        builder.Property(x => x.OptionB).IsRequired().HasMaxLength(500);
        builder.Property(x => x.OptionC).IsRequired().HasMaxLength(500);
        builder.Property(x => x.OptionD).IsRequired().HasMaxLength(500);
        builder.Property(x => x.CorrectOption).IsRequired();
        builder.Property(x => x.Origin).IsRequired();

        builder.Ignore(x => x.IsCorrect);
        builder.Ignore(x => x.IsDone);
        
        builder.HasOne(x => x.LessonAssessment)
            .WithMany(l => l.Questions)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.ModuleAssessment)
            .WithMany(m => m.Questions)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.RoadmapAssessment)
            .WithMany(r => r.Questions)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(x => x.IdLessonAssessment);
        builder.HasIndex(x => x.IdModuleAssessment);
        builder.HasIndex(x => x.IdRoadmapAssessment);
    }
}