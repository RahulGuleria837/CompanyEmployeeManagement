using Company_Employee_AuthenticationSystem;
using Company_Employee_AuthenticationSystem.DTOMapping;
using Company_Employee_AuthenticationSystem.Services;
using Company_Employee_AuthenticationSystem.Services.IServiceContract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);  

// Add services to the container.
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"), b => b.MigrationsAssembly("Company-Employee_AuthenticationSystem"));
});

// Set up ASP.NET Core Identity as a Service 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//builder.Services.AddScoped<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
//builder.Services.AddScoped<RoleManager<ApplicationRole>, ApplicationRoleManager>();
//builder.Services.AddScoped<ApplicationRoleStore>();

builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IUserService, UserService>();

//DTO
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company-Employee_AuthenticationSystem", Version = "v1" });
});
//JWT
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
var appsetting = appSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appsetting.SecretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{

    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
IServiceScopeFactory serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (IServiceScope scope = serviceScopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    if (!await roleManager.RoleExistsAsync(StandardDictionary.Role_Admin))
    {
        var role = new IdentityRole();
        role.Name = StandardDictionary.Role_Admin;
        await roleManager.CreateAsync(role);
    }
    if (!await roleManager.RoleExistsAsync(StandardDictionary.Role_Employee))
    {
        var role = new IdentityRole();
        role.Name = StandardDictionary.Role_Employee;
        await roleManager.CreateAsync(role);
    }
    if (!await roleManager.RoleExistsAsync(StandardDictionary.Role_Company))
    {
        var role = new IdentityRole();
        role.Name = StandardDictionary.Role_Company;
        await roleManager.CreateAsync(role);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
