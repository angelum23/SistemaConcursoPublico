using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class ExamConfig : IEntityTypeConfiguration<Exams>
{
    public void Configure(EntityTypeBuilder<Exams> builder)
    {
        builder.ToTable("exams");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany(u => u.Exams)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.NoticeTitle).HasMaxLength(250);
        builder.Property(x => x.NoticeDescription).HasColumnType("text");
        builder.Property(x => x.Notice).HasColumnType("text");
    }
}