using assistantServer.data.repository.Interface;
using assistantServer.data.repository;
using assistantServer.data;
using assistantServer.Servise.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using assistantServer.Servise;
using assistantServer.Mapper.Interface;
using assistantServer.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Настройка аутентификации: JWT + Cookie
builder.Services.AddAuthentication(options =>
{
    // JWT по умолчанию, если не указано другое
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Настройки для JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your_strong_secret_key_which_is_long_enough")),
        ValidateIssuer = false, // Не проверяем издателя
        ValidateAudience = false, // Не проверяем аудиторию
        ClockSkew = TimeSpan.Zero // Минимизируем смещение времени
    };
})
.AddCookie(options =>
{
    // Cookie-аутентификации
    options.LoginPath = "/AuthUser/Login";
});

// Авторизация
builder.Services.AddAuthorization();

// контроллеры и другие сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJwtTokenServise, JwtTokenServise>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserMapper, UserMapper>();


// Настройка подключения к базе данных
builder.Services.AddDbContext<AssistantDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AssistantDbContext")));

// Репозитории 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


// Настройка CORS
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.SetIsOriginAllowed(x => true); // Разрешаем любой origin (потом  можно ограничить)
        p.AllowCredentials(); // Разрешаем передавать cookies или токены
    });
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Конфигурация Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // Применяем политику CORS
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // Включаем аутентификацию
app.UseAuthorization(); // Включаем авторизацию
app.MapControllers(); // Маршрутизация контроллеров

app.Run();
