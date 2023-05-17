using EnrollCoursesAPI.Repositiory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionstr = $"Data Source={dbHost};Initial Catalog={dbName};TrustServerCertificate=true; User ID=sa;Password={dbPassword}";

var connectionString
    = builder
    .Configuration
    .GetConnectionString("AppDBContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");
builder.Services.AddDbContext<CourseDbContext>(options => options.UseSqlServer(connectionstr));
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<ITeacherRepo, TeacherRepo>();    
builder.Services.AddScoped<IEnrollCourseRepo, EnrollCourseRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
