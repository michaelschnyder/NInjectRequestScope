using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

using NInjectRequestScope.WebApi;
using NInjectRequestScope.WebApi.Controllers;

namespace NInjectRequestScope.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9001/";

            var types = typeof(DefaultController);

            // Start OWIN host 
            using (var app = WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/status").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}
