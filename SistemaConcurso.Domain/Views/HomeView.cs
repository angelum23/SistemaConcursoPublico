namespace SistemaConcurso.Domain.Views;

public record HomeView(
  int IdRoadmap,
  string RoadmapTitle,
  decimal Progress,
  DateTime CreatedAt,
  HomeExamView Exam,
  string SelectedJobTitle
);

public record HomeExamView(
  int IdExam,
  string NoticeTitle
);