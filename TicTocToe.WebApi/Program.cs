using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicTocToe.Bll.Abstract;
using TicTocToe.Bll.Concrete;
using TicTocToe.Dal.Contexts;
using TicTocToe.Dal.Data.Abstract;
using TicTocToe.Dal.Data.Concrete;
using TicTocToe.Model.Core.Abstract;
using TicTocToe.Model.Core.Concrete;
using TicTocToe.Model.Entities;


IConfiguration configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TicTocToeDbContext>(options =>
	options.UseSqlite());
builder.Services.AddScoped<IBaseEntity, BaseEntity>();
builder.Services.AddScoped<IDalGame, DalGame>();
builder.Services.AddScoped<IGameService, GameManager>();
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));


builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false; // Development için; Production'da true olmalý.
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = true,
		ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
		ValidateAudience = true,
		ValidAudience = jwtSettings.GetValue<string>("Audience"),
		ValidateLifetime = true
	};
});
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
	builder.WithOrigins("http://localhost:3000") // For testing vue
		   .AllowAnyHeader()
		   .AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
