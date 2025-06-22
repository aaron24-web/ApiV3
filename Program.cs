// JaveragesLibrary/Program.cs

using System.Text;
using JaveragesLibrary.Services.Features.Geometry;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Configuración de CORS ---
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// --- Configuración de Servicios ---
builder.Services.AddScoped<GeometryCalculationService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// --- Configuración de Autenticación JWT ---
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

// --- Configuración de Swagger para que muestre el botón de "Authorize" ---
builder.Services.AddSwaggerGen(options =>
{
    // ... (la configuración de SwaggerDoc que ya tenías) ...
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "v1", Title = "Geometry API" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, introduce 'Bearer' seguido de un espacio y el token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Pipeline de peticiones
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Geometry API V1");
        options.RoutePrefix = string.Empty;
    });
}

// app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

// El orden es importante:
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();