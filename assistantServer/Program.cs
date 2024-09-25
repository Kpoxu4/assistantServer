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

// ��������� ��������������: JWT + Cookie
builder.Services.AddAuthentication(options =>
{
    // JWT �� ���������, ���� �� ������� ������
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // ��������� ��� JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your_strong_secret_key_which_is_long_enough")),
        ValidateIssuer = false, // �� ��������� ��������
        ValidateAudience = false, // �� ��������� ���������
        ClockSkew = TimeSpan.Zero // ������������ �������� �������
    };
})
.AddCookie(options =>
{
    // Cookie-��������������
    options.LoginPath = "/AuthUser/Login";
});

// �����������
builder.Services.AddAuthorization();

// ����������� � ������ �������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJwtTokenServise, JwtTokenServise>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserMapper, UserMapper>();


// ��������� ����������� � ���� ������
builder.Services.AddDbContext<AssistantDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AssistantDbContext")));

// ����������� 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


// ��������� CORS
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.SetIsOriginAllowed(x => true); // ��������� ����� origin (�����  ����� ����������)
        p.AllowCredentials(); // ��������� ���������� cookies ��� ������
    });
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ������������ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // ��������� �������� CORS
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // �������� ��������������
app.UseAuthorization(); // �������� �����������
app.MapControllers(); // ������������� ������������

app.Run();
