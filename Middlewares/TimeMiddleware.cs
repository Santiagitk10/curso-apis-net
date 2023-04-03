

//UN MIDDLEWARE VA A TOMAR TODO EL REQUERIMIENTO Y VA A HACER ALGO ANTES DE MANDAR LA RESPUESTA. VA A INTERCEPTAR TODA LA RESPUESTA

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
        //Si en los parámetros del requerimiento tenga la key "time"
        if(context.Request.Query.Any(p=> p.Key == "time"))
        {
            //En la respuesta del context se escribe la hora del servidor
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

        //Una vez se haya completado el middleware se llama al siguiente middleware
        await next(context);
    }

}


    public static class TimeMiddlewareExtension
    {
        //Se recibe el IApplicationBuilder y se retorna con el middleware creado ya aplicado, por eso se usa this
        //en los parámetros. 
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
