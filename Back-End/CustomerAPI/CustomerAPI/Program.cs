using CustomerAPI.DAL.DataContext;
using CustomerAPI.DAL.Implementations;
using CustomerAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

/*      Otras formas de implementarlo
        .MinimumLevel.Information()
        .WriteTo.Console()
        .WriteTo.File("logs/newLogs.txt", rollingInterval: RollingInterval.Day)
         .CreateLogger();

    */
builder.Host.UseSerilog();   //Using this you can use the requestloggin of serilog and see things like the request that make an user
// Add services to the container.



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



app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Le decimos al constructor que vamos a utilizar el Cors ya definido.
app.UseCors("PolicyCors");

app.Run();
