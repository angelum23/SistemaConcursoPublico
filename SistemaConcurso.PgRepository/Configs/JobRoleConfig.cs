using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class JobRoleConfig : IEntityTypeConfiguration<JobRoles>
{
    public void Configure(EntityTypeBuilder<JobRoles> builder)
    {
        builder.ToTable("jobroles");
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Exam)
            .WithMany(e => e.JobRoles)
            .OnDelete(DeleteBehavior.Restrict);
    }
}