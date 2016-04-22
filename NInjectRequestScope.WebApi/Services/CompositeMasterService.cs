namespace NInjectRequestScope.WebApi.Services
{
    public class CompositeMasterService : ServiceBase, ISupportDependencyServiceA, ISupportDependencyServiceB
    {

        public CompositeSubService SubService { get; }

        public NoDependencyServiceA DependencyServiceA { get; }

        public NoDependencyServiceB DependencyServiceB { get; }

        public CompositeMasterService(CompositeSubService subService, NoDependencyServiceA serviceA, NoDependencyServiceB serviceB)
        {
            this.DependencyServiceA = serviceA;
            this.DependencyServiceB = serviceB;
            this.SubService = subService;
        }
    }
}