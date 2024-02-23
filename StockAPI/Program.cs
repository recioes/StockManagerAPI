using dotenv.net;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StockAPI.DI;
using StockAPI.Middleware;
using System.Text;
using static Mysqlx.Expect.Open.Types.Condition.Types;


Env.Load(".env");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterServices(builder.Configuration); // Registra servi�os personalizados.
builder.Services.AddSwaggerGen();

// Configura��o do JWT
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new InvalidOperationException("A vari�vel de ambiente JWT_KEY n�o est� configurada corretamente.");
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; 
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(5)


    };
});

builder.Services.AddAuthorization();

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
