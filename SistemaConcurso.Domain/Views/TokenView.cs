namespace SistemaConcurso.Domain.Views;

public record TokenView(string Token, string RefreshToken, DateTime ExpiresAt);