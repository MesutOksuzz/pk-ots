using System.Net;

namespace Ots.Api.Middleware;

public class HeartBeatMiddleware
{
    public readonly RequestDelegate next;
    
    public HeartBeatMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/api/Customers/GetAll"))
        {
            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsync("Hello world");
            return;
        }
        await next(context);
    }
}