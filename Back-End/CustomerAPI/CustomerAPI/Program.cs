using CustomerAPI.DAL.DataContext;
using CustomerAPI.DAL.Implementations;
using CustomerAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(e => e.LowercaseUrls = true);

builder.Services.AddDbContext<AplicationDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Creamos el Cors para permitir el acceso a la API desde cualquier origen, cabecera o metodo.
builder.Services.AddCors(opt 
    => opt.AddPolicy("PolicyCors", build 
    =>{
        build.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    }
));

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

//Le decimos al constructor que vamos a utilizar el Cors ya definido.
app.UseCors("PolicyCors");

app.Run();
