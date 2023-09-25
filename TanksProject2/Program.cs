using Microsoft.EntityFrameworkCore;
using TanksProject2.DAL.Data;
using TanksProject2.DAL.Interfaces;
using TanksProject2.DAL.Realization;
using TanksProject2.Servise.IServise;
using TanksProject2.Servise.Servise;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TanksProject2.Servise.Map.Mapper).Assembly);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyString")));

builder.Services.AddScoped<ITankInterface, TankRealization>();
builder.Services.AddScoped<ITankServise, TankServise>();

builder.Services.AddScoped<IUserAccountInterface, UserAccountRealization>();
builder.Services.AddScoped<IUserAccountServise, UserAccountServise>();

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

app.Run();
