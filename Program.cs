using DemoDbMigrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                config.GetConnectionString("Default"),
                b => {
                    b.MigrationsHistoryTable("__EFMigrationsHistory", "myapp");                    
                }
            )
        );

var app = builder.Build();

// Apply pending migrations automatically in development environment
// For production env., please use bundle feature (or CLI command)
if(app.Environment.IsDevelopment()){
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        // Strategy 1: Apply migrations directly
        dataContext.Database.MigrateAsync();

        // Strategy 2: Apply migrations from generated sql file
        // (Do not use ExecuteSqlRawAsync here, it will cause connection error)
        //dataContext.Database.ExecuteSqlRaw(File.ReadAllText("Data/migrations.sql"));
    }
}


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
