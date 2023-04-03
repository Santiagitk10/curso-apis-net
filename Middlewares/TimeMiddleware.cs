public class TimeMiddleware
{
    //Se usa para hacer el llamado al siguiente middleware
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    //HttpContext representa el requerimiento que viene en la petición http
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        if(context.Request.Query.Any(p=> p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

        await next(context);
    }

}


    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
