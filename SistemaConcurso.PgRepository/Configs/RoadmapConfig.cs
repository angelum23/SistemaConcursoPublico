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
            .WithMany(e => e.Roadmaps)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SelectedJobRole)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}