using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class LessonConfig : IEntityTypeConfiguration<Lessons>
{
    public void Configure(EntityTypeBuilder<Lessons> builder)
    {
        builder.ToTable("lessons");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.Description).HasColumnType("text");
        
        builder.HasOne(x => x.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(x => x.IdModule)
            .OnDelete(DeleteBehavior.Cascade);
    }
}