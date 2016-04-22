using System;

namespace NInjectRequestScope.WebApi.Services
{
    public class ServiceBase
    {
        public Guid Guid { get; private set; } = Guid.NewGuid();

        public string Id {
            get
            {
                return this.GetType().Name + "#" + this.Guid;
            }
        }
    }

    public class NoDependencyServiceA : ServiceBase
    {
    }

    public class NoDependencyServiceB: ServiceBase
    {
    }
}
