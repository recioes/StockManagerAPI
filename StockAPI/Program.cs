using dotenv.net;
using DotNetEnv;
using StockAPI.DI;
using StockAPI.Middleware;


Env.Load(".env");
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterServices(builder.Configuration); // Registra servi�os personalizados.
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger UI dispon�vel apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // Define o roteamento de requisi��es.


app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllers();

app.Run();
