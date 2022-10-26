//MAKE ONLY 3 TABLES IN SQL
using Microsoft.EntityFrameworkCore;
using RegisterApi.BL.Interfaces;
using RegisterApi.BL.Services;
using RegisterApi.DAL;
using RegisterApi.DAL.Interfaces;
using RegisterApi.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FullStackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Jwt")));
builder.Services.AddScoped<IDbRepository, DbRepository>();
builder.Services.AddScoped<IUserAccountsService, UserAccountsService>();
builder.Services.AddScoped<IJWTService, JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
