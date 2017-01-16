# WoodenMoose.AspNetCore.Exceptions
A small library for ASP.NET Core to allow returning HTTP codes in actions without changing the return type of the actions to IHttpResult.
Useful for WebAPI using Swagger automatic generation of API description.

Prerequisites
-------
This library will only work with ASP.NET Core projects targeting at least .NET Core 1.0

Installation
-------
A NuGet package of the library is available here : https://www.nuget.org/packages/WoodenMoose.AspNetCore.Exceptions/

Usage
-------
Once the NuGet package added in your project.json file, you only have to reference the middleware in the Configure method in Startup.cs

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
    loggerFactory.AddDebug();

    // Put this before UseMvc to be able to use it
    // But put it after logging/telemetry to avoid wrongly logging these exceptions
    app.UseHttpStatusCodeExceptions();

    app.UseMvc();
}
```
Just make sure to put it before `UseMvc()` in order to allow it to work.
If you happen to use logging or exception telemetry (like Application Insights), make sure you put `UseHttpStatusCodeExceptions()` after to avoid logging `HttpStatusCodeException`

Now you can use it into your controllers by throwing `HttpStatusCodeException`

```csharp
[HttpGet("{id}")]
public string Get(int id)
{
    if (id < 0)
        throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Id should be superior or equal to 0");

    if (id != 1)
        throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Value with id '{id}' doesn't exist");

    return "value";
}
```