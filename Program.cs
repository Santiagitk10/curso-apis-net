var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//Los middleware customs van después del Authorization. 
//Acá no se pasa el builder en el parámetro, porque en la clase del middleware se usa this en el parámetro. El app de
//por sí es el builder que envío
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
