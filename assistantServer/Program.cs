using assistantServer.data;
using assistantServer.data.repository.Interface;
using assistantServer.data.repository;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssistantDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("AssistantDbContext")));
//repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(o =>
{
    // правильное использование корсов
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();       
        p.SetIsOriginAllowed(x => true);
        p.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
