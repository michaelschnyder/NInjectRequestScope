using System;
using System.Net;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NInjectRequestScope.WebApi;
using System.Net.Http;
using Microsoft.Owin.Hosting;

using Newtonsoft.Json;

using NInjectRequestScope.WebApi.Controllers;

namespace NInjectRequestScope
{
    public class ControllerTestsBase
    {
        private IDisposable app;

        private string baseAddress;

        public ControllerTestsBase()
        {
            this.baseAddress = "http://localhost:9001/";

            var types = typeof(DefaultController);

            // Start OWIN host 
            this.app = WebApp.Start<InRequestScopeStartup>(url: this.baseAddress);

        }

        [TestCleanup]
        public void CleanUp()
        {
            this.app.Dispose();
        }

        protected HttpResponseMessage GetResponse(string route)
        {
            // Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();

            var response = client.GetAsync(this.baseAddress + route).Result;
            return response;
        }

        protected static void AssertOkResponseCode(HttpResponseMessage response)
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, response.Content.ReadAsStringAsync().Result);
        }
    }

    [TestClass]
    public class ControllerTests : ControllerTestsBase
    {
        [TestMethod]
        public void DefaultController_ReturnsOk()
        {
            var response = this.GetResponse("api/status");

            AssertOkResponseCode(response);
        }

    }
}
