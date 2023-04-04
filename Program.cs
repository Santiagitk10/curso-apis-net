using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//EL CONNECTION STRING POR BUENA PRÁCTICA SE DEBE ES AGREGAR EN EL APPSETTINGS Y LLAMARLO CON ARCHIVO DE CONFIGURACIÓN Y SECRETOS, ACÁ SE HACE DIRECTAMENTE EN EL PROGRAM
builder.Services.AddSqlServer<TareasContext>("Data Source=server;Initial Catalog=TareasDb;user id=sa;password=pass");
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
