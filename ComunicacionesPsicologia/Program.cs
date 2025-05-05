using ComunicacionesPsicologia.Context;
using Microsoft.EntityFrameworkCore;
using ComunicacionesPsicologia.Services;
using ComunicacionesPsicologia.Repository;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connec = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<CPContext>(options => options.UseSqlServer(connec));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Constructor para los servicios y repositorios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IConversacionRepository, ConversacionRepository>();

builder.Services.AddScoped<IRecursosService, RecursosService>();
builder.Services.AddScoped<IRecursosRepository, RecursosRepository>();


//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permitir solicitudes desde cualquier origen
                   .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
                   .AllowAnyHeader(); // Permitir cualquier cabecera
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
