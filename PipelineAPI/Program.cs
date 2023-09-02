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
        builder.WithOrigins("http://localhost:3000") // �stemcinizin k�k etki alan�n� ekleyin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// CORS politikas�n� etkinle�tirin

public void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", builder =>
        {
            builder.WithOrigins("http://localhost:3000") // �zin vermek istedi�iniz k�k etki alan�n� ekleyin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });

    // Di�er hizmetleri ekleyin
    services.AddControllers();
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ... Di�er kodlar ...

    app.UseCors("AllowLocalhost");

    // ... Di�er kodlar ...
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
