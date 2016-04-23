# NInjectRequestScope
How to use NInject with ASP.NET Web API on an OWIN Stack. 

The project contains a configuration and various tests to cover the folllwing special cases. The goal is to easily understand how NInject needs to be configured to achieve the following goals:

* One Instance per Request
* Same instance used even if different interfaces are requested

## Versions
Please use the latest Version of Ninject.Web.WebApi, See: http://stackoverflow.com/questions/28711963/ninject-activationexception-thrown-only-on-first-web-request-webapi-2-own-3-n

| Package                                | Version | Note |
|----------------------------------------|---------|------|
| Microsoft.AspNet.WebApi.Client         | 5.2.3   | Client Libraries used in Tests to parse server responses     |
| *Microsoft.AspNet.WebApi.Core*           | 5.2.3   |Required by Microsoft.AspNet.WebApi.Owin  |
| **Microsoft.AspNet.WebApi.Owin**           | 5.2.3   | Summary Package |
| *Microsoft.Owin*                         | 3.0.1   |Required by Microsoft.AspNet.WebApi.Owin      |
| **Microsoft.Owin.Host.HttpListener**       | 3.0.1   | Katana      |
| **Microsoft.Owin.Hosting**                 | 3.0.1   | Katana      |
| *Newtonsoft.Json*                        | 8.0.3   | Obvious usage     |
| **Ninject**                                | 3.2.2.0 | NINject Container      |
| *Ninject.Extensions.ContextPreservation* | 3.2.0.0 | Required by Ninject.Web.WebApi.OwinHost      |
| *Ninject.Extensions.NamedScope*          | 3.2.0.0 | Nequired by Ninject.Web.WebApi.OwinHost     |
| *Ninject.Web.Common*                    | 3.2.3.0 | Required by Ninject.Web.WebApi.OwinHost      |
| *Ninject.Web.Common.OwinHost*            | 3.2.3.0 | Required by Ninject.Web.WebApi.OwinHost    |
| *Ninject.Web.WebApi*                     | 3.2.4.0 | Required by Ninject.Web.WebApi.OwinHost     |
| **Ninject.Web.WebApi.OwinHost**            | 3.2.4.0 | Web API & OWIN Integration     |
| *Owin*                                   | 1.0     | Required by Microsoft.Owin, Microsoft Owin.Hosting, ...     |

**bold**: directly installed
*italic*: auto installed by dependency


# Known Issues
There are at least two known bugs related to this setup. See the following articles for details
* Incorrect implementation for WebApi with Owin (https://github.com/ninject/Ninject.Web.WebApi/issues/22)
* OWIN in RequestScope (https://github.com/ninject/Ninject.Web.WebApi/issues/23)

If this situations also apply to your project, I hightly recommend to **not** use the setup from this repository


#Author
Michael Schnyder
