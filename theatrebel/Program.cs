using Microsoft.EntityFrameworkCore;
using theatrebel;
using theatrebel.Data.Profiles;
using theatrebel.Repositories;
using theatrebel.Repositories.Interfaces;
using theatrebel.Services;
using theatrebel.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<TheatrebelContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("TheatrebelDb"))
    .UseSnakeCaseNamingConvention());

// Inject repos
services.AddScoped<IPlayRepository, PlayRepository>();
services.AddScoped<IWriterRepository, WriterRepository>();
services.AddScoped<IReviewRepository, ReviewRepository>();

// Inject services
services.AddScoped<IPlayService, PlayService>();
services.AddScoped<IWriterService, WriterService>();

// Inject profiles
services.AddAutoMapper(
    typeof(PlayProfile), 
    typeof(WriterProfile),
    typeof(ReviewProfile)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
