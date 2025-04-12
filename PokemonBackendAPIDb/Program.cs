using Microsoft.EntityFrameworkCore;
using PokemonBackendEFCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var env = builder.Configuration["Environment"];

if(env == "local")
{
    builder.Services.AddListPokemonRepository();
}
else
{
    builder.Services.AddPokemonBackendEFCore(builder.Configuration.GetConnectionString("DefaultConnection"));
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
