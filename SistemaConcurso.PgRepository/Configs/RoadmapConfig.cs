using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class RoadmapConfig : IEntityTypeConfiguration<Roadmaps>
{
    public void Configure(EntityTypeBuilder<Roadmaps> builder)
    {
        builder.ToTable("roadmaps");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).HasMaxLength(200);

        builder.HasOne(x => x.Exam)
            .WithOne(e => e.Roadmap)
            .HasForeignKey<Roadmaps>(r => r.IdExam)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.SelectedJobRole)
            .WithMany()
            .HasForeignKey(x => x.IdSelectedJobRole)
            .OnDelete(DeleteBehavior.Restrict);
    }
}