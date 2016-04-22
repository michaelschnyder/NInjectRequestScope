using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Newtonsoft.Json;

namespace NInjectRequestScope
{
    [TestClass]
    public class RequestScopeResolutionTests : ControllerTestsBase
    {
        [TestMethod]
        public void NoHiererchy_SingleDependency_ReturnsOk()
        {
            var response = this.GetResponse("test/singleDependency");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void NoHiererchy_MultipleDependencies_ReturnsOk()
        {
            var response = this.GetResponse("test/multipledependency");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void Composite_SingleDependency_ReturnsOk()
        {
            var response = this.GetResponse("test/compositeDependency");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void Composite_AdditionalSingleDependency_AreTheSame()
        {
            var response = this.GetResponse("test/compositeDependencyWithSingleDependency");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void CompositeRoot_SingleDependency_AreTheSame()
        {
            var response = this.GetResponse("test/compositeRoot");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void CompositeRoot_InterfacesDependency_AreTheSame()
        {
            var response = this.GetResponse("test/interfacedRootComposite");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        [TestMethod]
        public void CompositeRoot_InterfacesDependencyAndWithout_AreTheSame()
        {
            var response = this.GetResponse("test/interfacedAndDirectRootComposite");

            AssertOkResponseCode(response);
            AssertSameServiceInstances(response);
        }

        private static void AssertSameServiceInstances(HttpResponseMessage response)
        {
            var responseObj = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, new [] { new string[] {} });

            foreach (var serviceLine in responseObj)
            {
                var allAreTheSame = serviceLine.All(e => serviceLine.Count(c => c == e) == serviceLine.Length);

                Assert.IsTrue(allAreTheSame, "Not all services have the same instance! {0}", string.Join(",", serviceLine));
            }
        }
    }
}
