using FluentValidation.AspNetCore;
using MagazynEdu.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Validators.Users;
using PunchesManagement.ApplicationServices.Components.PasswordHasher;
using PunchesManagement.ApplicationServices.Mappings;
//using PunchesManagement.Authentication;
using PunchesManagement.DataAccess;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//NLog config
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddScoped<IPasswordHasher<User>, BCryptPasswordHasher<User>>();

//var authenticationSettings = new AuthenticationSettings();
//builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
//builder.Services.AddSingleton(authenticationSettings);
//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = "Bearer";
//    option.DefaultScheme = "Bearer";
//    option.DefaultChallengeScheme = "Bearer";
//}).AddJwtBearer(cfg =>
//{
//    cfg.RequireHttpsMetadata = false;
//    cfg.SaveToken = true;
//    cfg.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = authenticationSettings.JwtIssuer,
//        ValidAudience = authenticationSettings.JwtIssuer,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
//    };
//});

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<PunchesManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PunchesManagementDatabaseConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(ResponseBase<>));
builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);
builder.Services.AddMvcCore()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddUserRequestValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
