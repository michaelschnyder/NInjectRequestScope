
namespace NInjectRequestScope.WebApi.Services
{
    public interface ISupportDependencyServiceB
    {
        NoDependencyServiceB DependencyServiceB { get; }
        string Id { get; }
    }
}
