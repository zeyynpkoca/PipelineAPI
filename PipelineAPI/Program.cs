using PipelineAPI.HeatmapDbContextes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// We've add DBContext to define our database.(Dependency Injection)
builder.Services.AddDbContext<HeatmapDBContext>();
var app = builder.Build();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Ýstemcinizin kök etki alanýný ekleyin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// CORS politikasýný etkinleþtirin

public void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Ýzin vermek istediðiniz kök etki alanýný ekleyin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });

    // Diðer hizmetleri ekleyin
    services.AddControllers();
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ... Diðer kodlar ...

    app.UseCors("AllowLocalhost");

    // ... Diðer kodlar ...
}



app.UseCors("AllowLocalhost");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
