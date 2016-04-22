using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInjectRequestScope.WebApi.Services
{
    public interface ISupportDependencyServiceA
    {
        NoDependencyServiceA DependencyServiceA { get; }
        string Id { get; }
    }
}
