using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class Exams : BaseEntity
{
    public string NoticeTitle { get; set; } = string.Empty;
    public string NoticeDescription { get; set; } = string.Empty;
    public string Notice { get; set; } = string.Empty;
    
    [ForeignKey("User")]
    public int IdUser { get; set; }
    public Users? User { get; set; }

    public List<JobRoles> JobRoles { get; set; } = [];
    
    public List<Roadmaps> Roadmaps { get; set; }
}