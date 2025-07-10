using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Microsoft.EntityFrameworkCore;
using med_consult_api.src.application;
using med_consult_api.src.infrastructure;
using med_consult_api.src.presentation;
using med_consult_api.src.presentation.services;

var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────────────
// Configurações de Serviços
// ─────────────────────────────────────────────────────

// Swagger / API Docs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de Dados
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de Dependência
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAuthUserRepository), typeof(AuthUserRepository));

builder.Services.AddScoped(typeof(IService<,,,>), typeof(Service<,,,>));
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

builder.Services.AddScoped<IBcryptService, BcryptService>();

// JWT - Autenticação
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IJwtService, JwtService>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var jwtKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(jwtKey)
    };
});

builder.Services.AddAuthorization();

// Auto-registro de IMapper<,>
builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
    .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

// Controllers
builder.Services.AddControllers();


// ─────────────────────────────────────────────────────
// Pipeline da Aplicação
// ─────────────────────────────────────────────────────

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
