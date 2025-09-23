using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SistemaConcurso.Domain.Interfaces.DependencyInjection;

namespace SistemaConcurso.PgRepository.Base;

public static class PgModule
{
    public static IServiceCollection AddPgDbContext(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo<ISingletonDependency>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            .AddClasses(x => x.Where(y => y.GetInterfaces().All(z => z.Name != "ISingletonDependency")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        return services;
    }
}