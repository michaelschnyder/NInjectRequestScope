# NInjectRequestScope
How to use NInject with ASP.NET Web API on an OWIN Stack. 

The project contains a configuration and various tests to cover the folllwing special cases. The goal is to easily understand how NInject needs to be configured to achieve the following goals:

* One Instance per Request
* Same instance used even if different interfaces are requested

## Versions
Please use the latest Version of Ninject.Web.WebApi, See: * http://stackoverflow.com/questions/28711963/ninject-activationexception-thrown-only-on-first-web-request-webapi-2-own-3-n


# Known Issues
There are at least two known bugs related to this setup. See the following articles for details
* Incorrect implementation for WebApi with Owin (https://github.com/ninject/Ninject.Web.WebApi/issues/22)
* OWIN in RequestScope (https://github.com/ninject/Ninject.Web.WebApi/issues/23)

If this situations also apply to your project, I hightly recommend to **not** use the setup from this repository


#Author
Michael Schnyder
