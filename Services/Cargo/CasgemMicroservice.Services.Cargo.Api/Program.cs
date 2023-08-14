using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.BusinessLayer.Concrete;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete.Context;
using CasgemMicroservice.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.Authority = builder.Configuration["IdentityServerUrl"];
	opt.Audience = "resource_cargo";
	opt.RequireHttpsMetadata = false;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();

builder.Services.AddScoped<ICargoStateService, CargoStateManager>();
builder.Services.AddScoped<ICargoStateDal, EfCargoStateDal>();


//authenticationu controleler seviyesine çýkardýk
builder.Services.AddControllers(opt =>
{
	opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<CargoContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
