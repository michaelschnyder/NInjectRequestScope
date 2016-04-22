namespace NInjectRequestScope.WebApi.Services
{
    public class CompositeSubService : ServiceBase
    {
        public NoDependencyServiceA DependencyServiceA { get; }

        public NoDependencyServiceB DependencyServiceB { get; }

        public CompositeSubService(NoDependencyServiceA serviceA, NoDependencyServiceB serviceB)
        {
            this.DependencyServiceB = serviceB;
            this.DependencyServiceA = serviceA;
        }
    }
}