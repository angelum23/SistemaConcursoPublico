namespace SistemaConcurso.Domain.Views;

public record ModuleView(int Id, string Title, List<ModulesLessonView> Lessons);

public record ModulesLessonView(int Id, string Title, bool Done);