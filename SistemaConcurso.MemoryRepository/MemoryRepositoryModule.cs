using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaConcurso.Domain.Interfaces.DependencyInjection;

namespace SistemaConcurso.MemoryRepository;

public static class MemoryRepositoryModule
{
    public static IServiceCollection AddMemoryDbContext(this IServiceCollection services)
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