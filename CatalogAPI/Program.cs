using CatalogAPI.Context;
using CatalogAPI.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {options.Filters.Add(typeof(ApiExceptionFilter));})
.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); // definindo a string de conexão

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(SqlConnection)
); // fazendo a conexão com o banco de dados no contexto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    await next(context);
});

app.MapControllers();

app.Run();
