using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var CORSpolicy = "_CORSpolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSpolicy,  policy => {

        policy.WithOrigins("http://localhost:8080") // Permite apenas o frontend rodando em localhost:3000
            .AllowAnyHeader() // Permite qualquer cabeçalho
            .AllowAnyMethod(); // Permite qualquer método HTTP (GET, POST, etc.)
        });

});
builder.Services.AddControllers();


//Config do Swagger para documentação da API 1/2

builder.Services.AddEndpointsApiExplorer();


// Compativel com .NET 10
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new global::Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Sistema de Horas Extras",
        Version = "v1",
        Description = "API para gestão de solicitações de horas extras"
    });
});



var app = builder.Build();

//Config do Swagger para documentação da API 2/2

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Solicitação de Horas Extras v1");
        c.RoutePrefix = string.Empty; // Define a raiz para acessar a UI do Swagger (http://localhost:5000/)

    }
    );

//}



// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseCors(CORSpolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
